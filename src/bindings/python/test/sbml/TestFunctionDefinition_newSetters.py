#
# @file    TestFunctionDefinition_newSetters.py
# @brief   FunctionDefinition unit tests for new set function API
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating
#
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestFunctionDefinition_newSetters.c
# using the conversion program dev/utilities/translateTests/translateTests.pl.
# Any changes made here will be lost the next time the file is regenerated.
#
# -----------------------------------------------------------------------------
# This file is part of libSBML.  Please visit http://sbml.org for more
# information about SBML, and the latest version of libSBML.
#
# Copyright 2005-2010 California Institute of Technology.
# Copyright 2002-2005 California Institute of Technology and
#                     Japan Science and Technology Corporation.
#
# This library is free software; you can redistribute it and/or modify it
# under the terms of the GNU Lesser General Public License as published by
# the Free Software Foundation.  A copy of the license agreement is provided
# in the file named "LICENSE.txt" included with this software distribution
# and also available online as http://sbml.org/software/libsbml/license.html
# -----------------------------------------------------------------------------

import sys
import unittest
import libsbml


class TestFunctionDefinition_newSetters(unittest.TestCase):

  global E
  E = None

  def setUp(self):
    self.E = libsbml.FunctionDefinition(2,4)
    if (self.E == None):
      pass
    pass

  def tearDown(self):
    _dummyList = [ self.E ]; _dummyList[:] = []; del _dummyList
    pass

  def test_FunctionDefinition_setId1(self):
    id =  "1e1";
    i = self.E.setId(id)
    self.assert_( i == libsbml.LIBSBML_INVALID_ATTRIBUTE_VALUE )
    self.assertEqual( False, self.E.isSetId() )
    pass

  def test_FunctionDefinition_setId2(self):
    id =  "e1";
    i = self.E.setId(id)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_(( id == self.E.getId() ))
    self.assertEqual( True, self.E.isSetId() )
    i = self.E.setId("")
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.E.isSetId() )
    pass

  def test_FunctionDefinition_setMath1(self):
    math = libsbml.parseFormula("2 * k")
    i = self.E.setMath(math)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.E.getMath() != math )
    self.assertEqual( True, self.E.isSetMath() )
    i = self.E.setMath(None)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.E.getMath() == None )
    self.assertEqual( False, self.E.isSetMath() )
    _dummyList = [ math ]; _dummyList[:] = []; del _dummyList
    pass

  def test_FunctionDefinition_setMath2(self):
    math = libsbml.ASTNode(libsbml.AST_DIVIDE)
    i = self.E.setMath(math)
    self.assert_( i == libsbml.LIBSBML_INVALID_OBJECT )
    self.assertEqual( False, self.E.isSetMath() )
    _dummyList = [ math ]; _dummyList[:] = []; del _dummyList
    pass

  def test_FunctionDefinition_setName1(self):
    name =  "3Set_k2";
    i = self.E.setName(name)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( True, self.E.isSetName() )
    pass

  def test_FunctionDefinition_setName2(self):
    name =  "Set k2";
    i = self.E.setName(name)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_(( name == self.E.getName() ))
    self.assertEqual( True, self.E.isSetName() )
    i = self.E.unsetName()
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.E.isSetName() )
    pass

  def test_FunctionDefinition_setName3(self):
    i = self.E.setName("")
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.E.isSetName() )
    pass

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestFunctionDefinition_newSetters))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)
