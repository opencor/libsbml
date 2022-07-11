#
# @file    TestL3Event.py
# @brief   L3 Event unit tests
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating 
# 
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestL3Event.c
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


class TestL3Event(unittest.TestCase):

  global E
  E = None

  def setUp(self):
    self.E = libsbml.Event(3,1)
    if (self.E == None):
      pass    
    pass  

  def tearDown(self):
    _dummyList = [ self.E ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_NS(self):
    self.assertTrue( self.E.getNamespaces() != None )
    self.assertTrue( self.E.getNamespaces().getLength() == 1 )
    self.assertTrue((     "http://www.sbml.org/sbml/level3/version1/core" == self.E.getNamespaces().getURI(0) ))
    pass  

  def test_L3_Event_create(self):
    self.assertTrue( self.E.getTypeCode() == libsbml.SBML_EVENT )
    self.assertTrue( self.E.getMetaId() == "" )
    self.assertTrue( self.E.getNotes() == None )
    self.assertTrue( self.E.getAnnotation() == None )
    self.assertTrue( self.E.getId() == "" )
    self.assertTrue( self.E.getName() == "" )
    self.assertTrue( self.E.getUseValuesFromTriggerTime() == True )
    self.assertEqual( False, self.E.isSetId() )
    self.assertEqual( False, self.E.isSetName() )
    self.assertEqual( False, self.E.isSetUseValuesFromTriggerTime() )
    pass  

  def test_L3_Event_createWithNS(self):
    xmlns = libsbml.XMLNamespaces()
    xmlns.add( "http://www.sbml.org", "testsbml")
    sbmlns = libsbml.SBMLNamespaces(3,1)
    sbmlns.addNamespaces(xmlns)
    e = libsbml.Event(sbmlns)
    self.assertTrue( e.getTypeCode() == libsbml.SBML_EVENT )
    self.assertTrue( e.getMetaId() == "" )
    self.assertTrue( e.getNotes() == None )
    self.assertTrue( e.getAnnotation() == None )
    self.assertTrue( e.getLevel() == 3 )
    self.assertTrue( e.getVersion() == 1 )
    self.assertTrue( e.getNamespaces() != None )
    self.assertTrue( e.getNamespaces().getLength() == 2 )
    self.assertTrue( e.getId() == "" )
    self.assertTrue( e.getName() == "" )
    self.assertTrue( e.getUseValuesFromTriggerTime() == True )
    self.assertEqual( False, e.isSetId() )
    self.assertEqual( False, e.isSetName() )
    self.assertEqual( False, e.isSetUseValuesFromTriggerTime() )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_free_NULL(self):
    _dummyList = [ None ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_hasRequiredAttributes(self):
    e = libsbml.Event(3,1)
    self.assertEqual( False, e.hasRequiredAttributes() )
    e.setUseValuesFromTriggerTime(True)
    self.assertEqual( True, e.hasRequiredAttributes() )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_hasRequiredElements(self):
    e = libsbml.Event(3,1)
    self.assertEqual( False, e.hasRequiredElements() )
    t = libsbml.Trigger(3,1)
    t.setMath(libsbml.parseFormula("true"))
    t.setInitialValue(True)
    t.setPersistent(True)
    e.setTrigger(t)
    self.assertEqual( True, e.hasRequiredElements() )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_id(self):
    id =  "mitochondria";
    self.assertEqual( False, self.E.isSetId() )
    self.E.setId(id)
    self.assertTrue(( id == self.E.getId() ))
    self.assertEqual( True, self.E.isSetId() )
    if (self.E.getId() == id):
      pass    
    self.E.unsetId()
    self.assertEqual( False, self.E.isSetId() )
    if (self.E.getId() != None):
      pass    
    pass  

  def test_L3_Event_name(self):
    name =  "My_Favorite_Factory";
    self.assertEqual( False, self.E.isSetName() )
    self.E.setName(name)
    self.assertTrue(( name == self.E.getName() ))
    self.assertEqual( True, self.E.isSetName() )
    if (self.E.getName() == name):
      pass    
    self.E.unsetName()
    self.assertEqual( False, self.E.isSetName() )
    if (self.E.getName() != None):
      pass    
    pass  

  def test_L3_Event_setPriority1(self):
    priority = libsbml.Priority(3,1)
    math1 = libsbml.parseFormula("0")
    priority.setMath(math1)
    self.assertEqual( False, self.E.isSetPriority() )
    i = self.E.setPriority(priority)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( True, self.E.isSetPriority() )
    i = self.E.unsetPriority()
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.E.isSetPriority() )
    _dummyList = [ priority ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_L3_Event_setPriority2(self):
    priority = self.E.createPriority()
    self.assertEqual( True, self.E.isSetPriority() )
    p = self.E.getPriority()
    self.assertTrue( p != None )
    self.assertEqual( False, p.isSetMath() )
    pass  

  def test_L3_Event_useValuesFromTriggerTime(self):
    self.assertTrue( self.E.isSetUseValuesFromTriggerTime() == False )
    self.E.setUseValuesFromTriggerTime(True)
    self.assertTrue( self.E.getUseValuesFromTriggerTime() == True )
    self.assertTrue( self.E.isSetUseValuesFromTriggerTime() == True )
    self.E.setUseValuesFromTriggerTime(False)
    self.assertTrue( self.E.getUseValuesFromTriggerTime() == False )
    self.assertTrue( self.E.isSetUseValuesFromTriggerTime() == True )
    pass  

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestL3Event))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)
