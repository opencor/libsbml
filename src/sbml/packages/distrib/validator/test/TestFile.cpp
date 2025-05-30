/**
 * \file   TestFile.cpp
 * \brief  Enscapsulates an XML file in the test-data/ directory
 * \author Ben Bornstein
 * 
 * <!--------------------------------------------------------------------------
 * This file is part of libSBML.  Please visit http://sbml.org for more
 * information about SBML, and the latest version of libSBML.
 *
 * Copyright (C) 2020 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. University of Heidelberg, Heidelberg, Germany
 *     3. University College London, London, UK
 * 
 * Copyright (C) 2019 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. University of Heidelberg, Heidelberg, Germany
 *
 * Copyright (C) 2013-2018 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
 *     3. University of Heidelberg, Heidelberg, Germany
 * 
 * Copyright (C) 2009-2013 jointly by the following organizations: 
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
 *
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation.  A copy of the license agreement is provided
 * in the file named "LICENSE.txt" included with this software distribution
 * and also available online as http://sbml.org/software/libsbml/license.html
 * ---------------------------------------------------------------------- -->*/

#include <cstdlib>

#if defined(WIN32) && !defined(CYGWIN)
#  include "../../../../validator/test/tps/dirent.h"
#  include "../../../../validator/test/tps/dirent.c"
#else
#  include <sys/types.h>
#  include <dirent.h>
#endif  /* WIN32 */

#include <iostream>
#include "TestFile.h"

/** @cond doxygenIgnored */

using namespace std;

/** @endcond */


/**
 * TestFiles (e.g. in the test-data/ directory) have the following naming
 * convention:
 *
 *   ccccccc-pass-00-nn.xml, or
 *   ccccccc-fail-ff-nn.xml
 *
 *   ccccccc-fail-ff-nn-xxxxx.xml
 *
 * Where:
 *
 *   ccccccc  is the seven digit constraint id the file is designed to test
 *
 *   pass   indicates the file must pass validation without error
 *
 *   fail   indicates the file must fail validation with extactly ff errors
 *          all with constraint id ccccc.
 *
 *   nn     is the sequence id (to allow multiple test files per constraint).
 *
 *   xxxxx  is the number of an additional constraint that this test fails
 *
 *
 * Offsets within mFilename:
 *
 *           1        1
 * 012345678901234567890123456
 * ccccccc-pass-00-nn.xml
 * ccccccc-fail-ff-nn.xml
 * ccccccc-fail-ff-nn-xxxxx.xml
 */


std::string
TestFile::getFullname () const
{
  return mDirectory + "/" + mFilename;
}


unsigned int
TestFile::getConstraintId () const
{ 
    unsigned int constraint = atol( mFilename.substr(0, 7).c_str() );

    return constraint;
}


unsigned int
TestFile::getSequenceId () const
{
  return atol( mFilename.substr(16, 2).c_str() );
}


unsigned int
TestFile::getNumFailures () const
{
  unsigned num = atol( mFilename.substr(13, 2).c_str() );
  if (mFilename.length() > 22)
    return num+1;
  else
    return num;
}

unsigned int
TestFile::getAdditionalFailId () const
{
  if (mFilename.length() > 22)
    return atol( mFilename.substr(19, 7).c_str() );
  else
    return 0;

}


/**
 * @return true if filename adheres to the TestFile naming convention,
 * false otherwise.
 */
bool
TestFile::isValid (const string& filename)
{
  return ((filename.length() == 22 && filename.substr(18, 4) == ".xml")
    || (filename.length() == 30 && filename.substr(26, 4) == ".xml"));
}


/**
 * @return the set of TestFiles in the given directory.
 *
 * You may optionally limit to the TestFiles returned to only those with
 * ConstraintIds in the range [begin, end] (if begin == end == 0, all
 * TestFiles in the given directory will be returned).
 */
set<TestFile>
TestFile::getFilesIn ( const string& directory,
                       unsigned int  begin,
                       unsigned int  end,
                       unsigned int  library)
{
  DIR*           dir;
  struct dirent* entry;
  set<TestFile>  result;

  dir = opendir( directory.c_str() );

  if (dir == NULL)
  {
    cerr << "Could not obtain a list of files in directory "
         << "[" << directory << "]." << endl;
    return result;
  }

  for (entry = readdir(dir); entry != NULL; entry = readdir(dir))
  {
    string filename(entry->d_name);

    if ( TestFile::isValid(filename) )
    {
      TestFile     file(directory, filename);
      unsigned int id = file.getConstraintId();
      if (begin == 1)
          id = id - 1500000;
      //// leave out the following tests dependent on parser
      //if (library == 0)
      //{
      // // xerces bug in reading multibyte chars
      //  if (id == 10309) continue;

        // libxml bug for 2.6.16 on a Mac
#ifdef BUGGY_APPLE_LIBXML
      // unsigned int num = file.getSequenceId();

      if (id == 1013) continue;
      if (id == 1014) continue;
#endif

      // leave out model constraints moved to units
      if (id == 20702 || id == 20616
        || id == 20511 || id == 20512 || id == 20513
        || id == 20518)
        continue;
      //}

      if ((begin == 0 && end == 0) || (id >= begin && id <= end) || (begin == 1 && end == 0))
      {
        result.insert( TestFile(directory, filename) );
      }
    }
  }

  closedir(dir);

  return result;
}
