///  @file    TestListOf.cs
///  @brief   ListOf unit tests
///  @author  Frank Bergmann (Csharp conversion)
///  @author  Akiya Jouraku (Csharp conversion)
///  @author  Ben Bornstein
///
///
///  ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
///
///  DO NOT EDIT THIS FILE.
///
///  This file was generated automatically by converting the file located at
///  src/sbml/test/TestListOf.c
///  using the conversion program dev/utilities/translateTests/translateTests.pl.
///  Any changes made here will be lost the next time the file is regenerated.
///
///  -----------------------------------------------------------------------------
///  This file is part of libSBML.  Please visit http://sbml.org for more
///  information about SBML, and the latest version of libSBML.
///
///  Copyright 2005-2010 California Institute of Technology.
///  Copyright 2002-2005 California Institute of Technology and
///                      Japan Science and Technology Corporation.
///
///  This library is free software; you can redistribute it and/or modify it
///  under the terms of the GNU Lesser General Public License as published by
///  the Free Software Foundation.  A copy of the license agreement is provided
///  in the file named "LICENSE.txt" included with this software distribution
///  and also available online as http://sbml.org/software/libsbml/license.html
///  -----------------------------------------------------------------------------


namespace LibSBMLCSTest.sbml {

  using libsbmlcs;

  using System;

  using System.IO;

  public class TestListOf {
    public class AssertionError : System.Exception
    {
      public AssertionError() : base()
      {

      }
    }


    static void assertTrue(bool condition)
    {
      if (condition == true)
      {
        return;
      }
      throw new AssertionError();
    }

    static void assertEquals(object a, object b)
    {
      if ( (a == null) && (b == null) )
      {
        return;
      }
      else if ( (a == null) || (b == null) )
      {
        throw new AssertionError();
      }
      else if (a.Equals(b))
      {
        return;
      }

      throw new AssertionError();
    }

    static void assertNotEquals(object a, object b)
    {
      if ( (a == null) && (b == null) )
      {
        throw new AssertionError();
      }
      else if ( (a == null) || (b == null) )
      {
        return;
      }
      else if (a.Equals(b))
      {
        throw new AssertionError();
      }
    }

    static void assertEquals(bool a, bool b)
    {
      if ( a == b )
      {
        return;
      }
      throw new AssertionError();
    }

    static void assertNotEquals(bool a, bool b)
    {
      if ( a != b )
      {
        return;
      }
      throw new AssertionError();
    }

    static void assertEquals(int a, int b)
    {
      if ( a == b )
      {
        return;
      }
      throw new AssertionError();
    }

    static void assertNotEquals(int a, int b)
    {
      if ( a != b )
      {
        return;
      }
      throw new AssertionError();
    }


    public void test_ListOf_append()
    {
      Model m = new  Model(2,4);
      m.createCompartment();
      ListOf loc = m.getListOfCompartments();
      assertTrue( loc.size() == 1 );
      SBase c = new  Compartment(2,4);
      int i = loc.append(c);
      assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS );
      assertTrue( loc.size() == 2 );
      SBase sp = new  Species(2,4);
      i = loc.append(sp);
      assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT );
      assertTrue( loc.size() == 2 );
      m = null;
      sp = null;
    }

    public void test_ListOf_clear()
    {
      ListOf lo = new  ListOf(2,4);
      SBase sp = new  Species(2,4);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      assertTrue( lo.size() == 5 );
      lo.clear(true);
      assertTrue( lo.size() == 0 );
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.appendAndOwn(sp);
      assertTrue( lo.size() == 5 );
      SBase elem;
      elem = lo.get(0);
      elem = null;
      elem = lo.get(1);
      elem = null;
      elem = lo.get(2);
      elem = null;
      elem = lo.get(3);
      elem = null;
      elem = lo.get(4);
      elem = null;
      lo.clear(false);
      assertTrue( lo.size() == 0 );
      lo = null;
    }

    public void test_ListOf_create()
    {
      ListOf lo = new  ListOf(2,4);
      assertTrue( lo.getTypeCode() == libsbml.SBML_LIST_OF );
      assertTrue( lo.getNotes() == null );
      assertTrue( lo.getAnnotation() == null );
      assertTrue( lo.getMetaId() == "" );
      assertTrue( lo.size() == 0 );
      lo = null;
    }

    public void test_ListOf_free_NULL()
    {
    }

    public void test_ListOf_remove()
    {
      ListOf lo = new  ListOf(2,4);
      SBase sp = new  Species(2,4);
      assertTrue( lo.size() == 0 );
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      assertTrue( lo.size() == 5 );
      SBase elem;
      elem = lo.remove(0);
      elem = null;
      elem = lo.remove(0);
      elem = null;
      elem = lo.remove(0);
      elem = null;
      elem = lo.remove(0);
      elem = null;
      elem = lo.remove(0);
      elem = null;
      assertTrue( lo.size() == 0 );
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.append(sp);
      lo.appendAndOwn(sp);
      assertTrue( lo.size() == 5 );
      lo = null;
    }

  }
}

