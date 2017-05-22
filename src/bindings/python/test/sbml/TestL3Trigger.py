#
# @file    TestL3Trigger.py
# @brief   SBML Trigger unit tests
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating
#
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestL3Trigger.c
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


class TestL3Trigger(unittest.TestCase):

  global T
  T = None

  def setUp(self):
    self.T = libsbml.Trigger(3,1)
    if (self.T == None):
      pass
    pass

  def tearDown(self):
    _dummyList = [ self.T ]; _dummyList[:] = []; del _dummyList
    pass

  def test_L3Trigger_create(self):
    self.assert_( self.T.getTypeCode() == libsbml.SBML_TRIGGER )
    self.assert_( self.T.getMetaId() == "" )
    self.assert_( self.T.getNotes() == None )
    self.assert_( self.T.getAnnotation() == None )
    self.assert_( self.T.getMath() == None )
    self.assert_( self.T.getInitialValue() == True )
    self.assert_( self.T.getPersistent() == True )
    self.assert_( self.T.isSetInitialValue() == False )
    self.assert_( self.T.isSetPersistent() == False )
    pass

  def test_L3Trigger_setInitialValue(self):
    i = self.T.setInitialValue(False)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.T.getInitialValue() == False )
    self.assert_( self.T.isSetInitialValue() == True )
    i = self.T.setInitialValue(True)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.T.getInitialValue() == True )
    self.assert_( self.T.isSetInitialValue() == True )
    pass

  def test_L3Trigger_setInitialValue1(self):
    t = libsbml.Trigger(2,4)
    i = t.setInitialValue(False)
    self.assert_( i == libsbml.LIBSBML_UNEXPECTED_ATTRIBUTE )
    self.assert_( self.T.getInitialValue() == True )
    self.assert_( self.T.isSetInitialValue() == False )
    _dummyList = [ t ]; _dummyList[:] = []; del _dummyList
    pass

  def test_L3Trigger_setPersistent(self):
    i = self.T.setPersistent(False)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.T.getPersistent() == False )
    self.assert_( self.T.isSetPersistent() == True )
    i = self.T.setPersistent(True)
    self.assert_( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assert_( self.T.getPersistent() == True )
    self.assert_( self.T.isSetPersistent() == True )
    pass

  def test_L3Trigger_setPersistent1(self):
    t = libsbml.Trigger(2,4)
    i = t.setPersistent(False)
    self.assert_( i == libsbml.LIBSBML_UNEXPECTED_ATTRIBUTE )
    self.assert_( self.T.getPersistent() == True )
    self.assert_( self.T.isSetPersistent() == False )
    _dummyList = [ t ]; _dummyList[:] = []; del _dummyList
    pass

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestL3Trigger))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)

