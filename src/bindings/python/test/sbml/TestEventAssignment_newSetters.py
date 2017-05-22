#
# @file    TestEventAssignment_newSetters.py
# @brief   EventAssignment unit tests for new set function API
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating
#
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestEventAssignment_newSetters.c
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


class TestEventAssignment_newSetters(unittest.TestCase):

  global E
  E = None

  def setUp(self):
    self.E = libsbml.EventAssignment(2,4)
    if (self.E == None):
      pass
    pass

  def tearDown(self):
    _dummyList = [ self.E ]; _dummyList[:] = []; del _dummyList
    pass

  def test_EventAssignment_setMath1(self):
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

  def test_EventAssignment_setMath2(self):
    math = libsbml.ASTNode(libsbml.AST_DIVIDE)
    i = self.E.setMath(math)
    self.assert_( i == libsbml.LIBSBML_INVALID_OBJECT )
    self.assertEqual( False, self.E.isSetMath() )
    _dummyList = [ math ]; _dummyList[:] = []; del _dummyList
    pass

  def test_EventAssignment_setVariable1(self):
    id =  "1e1";
    i = self.E.setVariable(id)
    self.assert_( i == libsbml.LIBSBML_INVALID_ATTRIBUTE_VALUE )
    self.assertEqual( False, self.E.isSetVariable() )
    pass

  def test_EventAssignment_setVariable2(self):
    id =  "e1";
    i = self.E.setVariable(id)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_(( id == self.E.getVariable() ))
    self.assertEqual( True, self.E.isSetVariable() )
    i = self.E.setVariable("")
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.E.isSetVariable() )
    pass

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestEventAssignment_newSetters))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)
