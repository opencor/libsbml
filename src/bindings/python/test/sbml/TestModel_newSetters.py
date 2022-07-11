#
# @file    TestModel_newSetters.py
# @brief   Model unit tests for new set function API
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating 
# 
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestModel_newSetters.c
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


class TestModel_newSetters(unittest.TestCase):

  global M
  M = None

  def setUp(self):
    self.M = libsbml.Model(2,4)
    if (self.M == None):
      pass    
    pass  

  def tearDown(self):
    _dummyList = [ self.M ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartment1(self):
    m = libsbml.Model(2,2)
    c = libsbml.Compartment(2,2)
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    c.setId( "c")
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumCompartments() == 1 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartment2(self):
    m = libsbml.Model(2,2)
    c = libsbml.Compartment(2,1)
    c.setId( "c")
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumCompartments() == 0 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartment3(self):
    m = libsbml.Model(2,2)
    c = libsbml.Compartment(1,2)
    c.setId( "c")
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumCompartments() == 0 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartment4(self):
    m = libsbml.Model(2,2)
    c = None
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumCompartments() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartment5(self):
    m = libsbml.Model(2,2)
    c = libsbml.Compartment(2,2)
    c.setId( "c")
    c1 = libsbml.Compartment(2,2)
    c1.setId( "c")
    i = m.addCompartment(c)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumCompartments() == 1 )
    i = m.addCompartment(c1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumCompartments() == 1 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ c1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartmentType1(self):
    m = libsbml.Model(2,2)
    ct = libsbml.CompartmentType(2,2)
    i = m.addCompartmentType(ct)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    ct.setId( "ct")
    i = m.addCompartmentType(ct)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumCompartmentTypes() == 1 )
    _dummyList = [ ct ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartmentType2(self):
    m = libsbml.Model(2,2)
    ct = libsbml.CompartmentType(2,3)
    ct.setId( "ct")
    i = m.addCompartmentType(ct)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumCompartmentTypes() == 0 )
    _dummyList = [ ct ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartmentType3(self):
    m = libsbml.Model(2,2)
    ct = None
    i = m.addCompartmentType(ct)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumCompartmentTypes() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addCompartmentType4(self):
    m = libsbml.Model(2,2)
    ct = libsbml.CompartmentType(2,2)
    ct.setId( "ct")
    ct1 = libsbml.CompartmentType(2,2)
    ct1.setId( "ct")
    i = m.addCompartmentType(ct)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumCompartmentTypes() == 1 )
    i = m.addCompartmentType(ct1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumCompartmentTypes() == 1 )
    _dummyList = [ ct ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ ct1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addConstraint1(self):
    m = libsbml.Model(2,2)
    c = libsbml.Constraint(2,2)
    i = m.addConstraint(c)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    c.setMath(libsbml.parseFormula("a+b"))
    i = m.addConstraint(c)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumConstraints() == 1 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addConstraint2(self):
    m = libsbml.Model(2,2)
    c = libsbml.Constraint(2,3)
    c.setMath(libsbml.parseFormula("a+b"))
    i = m.addConstraint(c)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumConstraints() == 0 )
    _dummyList = [ c ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addConstraint3(self):
    m = libsbml.Model(2,2)
    c = None
    i = m.addConstraint(c)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumConstraints() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addEvent1(self):
    m = libsbml.Model(2,2)
    e = libsbml.Event(2,2)
    t = libsbml.Trigger(2,2)
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    t.setMath(libsbml.parseFormula("true"))
    e.setTrigger(t)
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    e.createEventAssignment()
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumEvents() == 1 )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addEvent2(self):
    m = libsbml.Model(2,2)
    e = libsbml.Event(2,1)
    t = libsbml.Trigger(2,1)
    t.setMath(libsbml.parseFormula("true"))
    e.setTrigger(t)
    e.createEventAssignment()
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumEvents() == 0 )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addEvent3(self):
    m = libsbml.Model(2,2)
    e = None
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumEvents() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addEvent4(self):
    m = libsbml.Model(2,2)
    e = libsbml.Event(2,2)
    t = libsbml.Trigger(2,2)
    t.setMath(libsbml.parseFormula("true"))
    e.setId( "e")
    e.setTrigger(t)
    e.createEventAssignment()
    e1 = libsbml.Event(2,2)
    e1.setId( "e")
    e1.setTrigger(t)
    e1.createEventAssignment()
    i = m.addEvent(e)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumEvents() == 1 )
    i = m.addEvent(e1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumEvents() == 1 )
    _dummyList = [ e ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ e1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addFunctionDefinition1(self):
    m = libsbml.Model(2,2)
    fd = libsbml.FunctionDefinition(2,2)
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    fd.setId( "fd")
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    fd.setMath(libsbml.parseFormula("fd"))
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumFunctionDefinitions() == 1 )
    _dummyList = [ fd ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addFunctionDefinition2(self):
    m = libsbml.Model(2,2)
    fd = libsbml.FunctionDefinition(2,1)
    fd.setId( "fd")
    fd.setMath(libsbml.parseFormula("fd"))
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumFunctionDefinitions() == 0 )
    _dummyList = [ fd ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addFunctionDefinition3(self):
    m = libsbml.Model(2,2)
    fd = None
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumFunctionDefinitions() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addFunctionDefinition4(self):
    m = libsbml.Model(2,2)
    fd = libsbml.FunctionDefinition(2,2)
    fd.setId( "fd")
    fd.setMath(libsbml.parseFormula("fd"))
    fd1 = libsbml.FunctionDefinition(2,2)
    fd1.setId( "fd")
    fd1.setMath(libsbml.parseFormula("fd"))
    i = m.addFunctionDefinition(fd)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumFunctionDefinitions() == 1 )
    i = m.addFunctionDefinition(fd1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumFunctionDefinitions() == 1 )
    _dummyList = [ fd ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ fd1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addInitialAssignment1(self):
    m = libsbml.Model(2,2)
    ia = libsbml.InitialAssignment(2,2)
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    ia.setSymbol( "i")
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    ia.setMath(libsbml.parseFormula("gg"))
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumInitialAssignments() == 1 )
    _dummyList = [ ia ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addInitialAssignment2(self):
    m = libsbml.Model(2,2)
    ia = libsbml.InitialAssignment(2,3)
    ia.setSymbol( "i")
    ia.setMath(libsbml.parseFormula("gg"))
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumInitialAssignments() == 0 )
    _dummyList = [ ia ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addInitialAssignment3(self):
    m = libsbml.Model(2,2)
    ia = None
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumInitialAssignments() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addInitialAssignment4(self):
    m = libsbml.Model(2,2)
    ia = libsbml.InitialAssignment(2,2)
    ia.setSymbol( "ia")
    ia.setMath(libsbml.parseFormula("a+b"))
    ia1 = libsbml.InitialAssignment(2,2)
    ia1.setSymbol( "ia")
    ia1.setMath(libsbml.parseFormula("a+b"))
    i = m.addInitialAssignment(ia)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumInitialAssignments() == 1 )
    i = m.addInitialAssignment(ia1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumInitialAssignments() == 1 )
    _dummyList = [ ia ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ ia1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addParameter1(self):
    m = libsbml.Model(2,2)
    p = libsbml.Parameter(2,2)
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    p.setId( "p")
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumParameters() == 1 )
    _dummyList = [ p ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addParameter2(self):
    m = libsbml.Model(2,2)
    p = libsbml.Parameter(2,1)
    p.setId( "p")
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumParameters() == 0 )
    _dummyList = [ p ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addParameter3(self):
    m = libsbml.Model(2,2)
    p = libsbml.Parameter(1,2)
    p.setId( "p")
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumParameters() == 0 )
    _dummyList = [ p ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addParameter4(self):
    m = libsbml.Model(2,2)
    p = None
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumParameters() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addParameter5(self):
    m = libsbml.Model(2,2)
    p = libsbml.Parameter(2,2)
    p.setId( "p")
    p1 = libsbml.Parameter(2,2)
    p1.setId( "p")
    i = m.addParameter(p)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumParameters() == 1 )
    i = m.addParameter(p1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumParameters() == 1 )
    _dummyList = [ p ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ p1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addReaction1(self):
    m = libsbml.Model(2,2)
    r = libsbml.Reaction(2,2)
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    r.setId( "r")
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumReactions() == 1 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addReaction2(self):
    m = libsbml.Model(2,2)
    r = libsbml.Reaction(2,1)
    r.setId( "r")
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumReactions() == 0 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addReaction3(self):
    m = libsbml.Model(2,2)
    r = libsbml.Reaction(1,2)
    r.setId( "r")
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumReactions() == 0 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addReaction4(self):
    m = libsbml.Model(2,2)
    r = None
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumReactions() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addReaction5(self):
    m = libsbml.Model(2,2)
    r = libsbml.Reaction(2,2)
    r.setId( "r")
    r1 = libsbml.Reaction(2,2)
    r1.setId( "r")
    i = m.addReaction(r)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumReactions() == 1 )
    i = m.addReaction(r1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumReactions() == 1 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ r1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addRule1(self):
    m = libsbml.Model(2,2)
    r = libsbml.AssignmentRule(2,2)
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    r.setVariable( "f")
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    r.setMath(libsbml.parseFormula("a-n"))
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumRules() == 1 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addRule2(self):
    m = libsbml.Model(2,2)
    r = libsbml.AssignmentRule(2,1)
    r.setVariable( "f")
    r.setMath(libsbml.parseFormula("a-n"))
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumRules() == 0 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addRule3(self):
    m = libsbml.Model(2,2)
    r = libsbml.AssignmentRule(1,2)
    r.setVariable( "f")
    r.setMath(libsbml.parseFormula("a-n"))
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumRules() == 0 )
    _dummyList = [ r ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addRule4(self):
    m = libsbml.Model(2,2)
    r = None
    i = m.addRule(r)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumRules() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addRule5(self):
    m = libsbml.Model(2,2)
    ar = libsbml.AssignmentRule(2,2)
    ar.setVariable( "ar")
    ar.setMath(libsbml.parseFormula("a-j"))
    ar1 = libsbml.AssignmentRule(2,2)
    ar1.setVariable( "ar")
    ar1.setMath(libsbml.parseFormula("a-j"))
    i = m.addRule(ar)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumRules() == 1 )
    i = m.addRule(ar1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumRules() == 1 )
    _dummyList = [ ar ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ ar1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpecies1(self):
    m = libsbml.Model(2,2)
    s = libsbml.Species(2,2)
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    s.setId( "s")
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    s.setCompartment( "c")
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumSpecies() == 1 )
    _dummyList = [ s ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpecies2(self):
    m = libsbml.Model(2,2)
    s = libsbml.Species(2,1)
    s.setId( "s")
    s.setCompartment( "c")
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumSpecies() == 0 )
    _dummyList = [ s ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpecies3(self):
    m = libsbml.Model(2,2)
    s = libsbml.Species(1,2)
    s.setId( "s")
    s.setCompartment( "c")
    s.setInitialAmount(2)
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumSpecies() == 0 )
    _dummyList = [ s ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpecies4(self):
    m = libsbml.Model(2,2)
    s = None
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumSpecies() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpecies5(self):
    m = libsbml.Model(2,2)
    s = libsbml.Species(2,2)
    s.setId( "s")
    s.setCompartment( "c")
    s1 = libsbml.Species(2,2)
    s1.setId( "s")
    s1.setCompartment( "c")
    i = m.addSpecies(s)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumSpecies() == 1 )
    i = m.addSpecies(s1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumSpecies() == 1 )
    _dummyList = [ s ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ s1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpeciesType1(self):
    m = libsbml.Model(2,2)
    st = libsbml.SpeciesType(2,2)
    i = m.addSpeciesType(st)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    st.setId( "st")
    i = m.addSpeciesType(st)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumSpeciesTypes() == 1 )
    _dummyList = [ st ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpeciesType2(self):
    m = libsbml.Model(2,2)
    st = libsbml.SpeciesType(2,3)
    st.setId( "st")
    i = m.addSpeciesType(st)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumSpeciesTypes() == 0 )
    _dummyList = [ st ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpeciesType3(self):
    m = libsbml.Model(2,2)
    st = None
    i = m.addSpeciesType(st)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumSpeciesTypes() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addSpeciesType4(self):
    m = libsbml.Model(2,2)
    st = libsbml.SpeciesType(2,2)
    st.setId( "st")
    st1 = libsbml.SpeciesType(2,2)
    st1.setId( "st")
    i = m.addSpeciesType(st)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumSpeciesTypes() == 1 )
    i = m.addSpeciesType(st1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumSpeciesTypes() == 1 )
    _dummyList = [ st ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ st1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addUnitDefinition1(self):
    m = libsbml.Model(2,2)
    ud = libsbml.UnitDefinition(2,2)
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    ud.createUnit()
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    ud.setId( "ud")
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumUnitDefinitions() == 1 )
    _dummyList = [ ud ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addUnitDefinition2(self):
    m = libsbml.Model(2,2)
    ud = libsbml.UnitDefinition(2,1)
    ud.createUnit()
    ud.setId( "ud")
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_VERSION_MISMATCH )
    self.assertTrue( m.getNumUnitDefinitions() == 0 )
    _dummyList = [ ud ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addUnitDefinition3(self):
    m = libsbml.Model(2,2)
    ud = libsbml.UnitDefinition(1,2)
    ud.createUnit()
    ud.setId( "ud")
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_LEVEL_MISMATCH )
    self.assertTrue( m.getNumUnitDefinitions() == 0 )
    _dummyList = [ ud ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addUnitDefinition4(self):
    m = libsbml.Model(2,2)
    ud = None
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_FAILED )
    self.assertTrue( m.getNumUnitDefinitions() == 0 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_addUnitDefinition5(self):
    m = libsbml.Model(2,2)
    ud = libsbml.UnitDefinition(2,2)
    ud.setId( "ud")
    ud.createUnit()
    ud1 = libsbml.UnitDefinition(2,2)
    ud1.setId( "ud")
    ud1.createUnit()
    i = m.addUnitDefinition(ud)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue( m.getNumUnitDefinitions() == 1 )
    i = m.addUnitDefinition(ud1)
    self.assertTrue( i == libsbml.LIBSBML_DUPLICATE_OBJECT_ID )
    self.assertTrue( m.getNumUnitDefinitions() == 1 )
    _dummyList = [ ud ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ ud1 ]; _dummyList[:] = []; del _dummyList
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createCompartment(self):
    m = libsbml.Model(2,2)
    p = m.createCompartment()
    self.assertTrue( m.getNumCompartments() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createCompartmentType(self):
    m = libsbml.Model(2,2)
    p = m.createCompartmentType()
    self.assertTrue( m.getNumCompartmentTypes() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createConstraint(self):
    m = libsbml.Model(2,2)
    p = m.createConstraint()
    self.assertTrue( m.getNumConstraints() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createEvent(self):
    m = libsbml.Model(2,2)
    p = m.createEvent()
    self.assertTrue( m.getNumEvents() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createEventAssignment(self):
    m = libsbml.Model(2,2)
    p = m.createEvent()
    ea = m.createEventAssignment()
    self.assertTrue( p.getNumEventAssignments() == 1 )
    self.assertTrue( (ea).getLevel() == 2 )
    self.assertTrue( (ea).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createFunctionDefinition(self):
    m = libsbml.Model(2,2)
    p = m.createFunctionDefinition()
    self.assertTrue( m.getNumFunctionDefinitions() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createInitialAssignment(self):
    m = libsbml.Model(2,2)
    p = m.createInitialAssignment()
    self.assertTrue( m.getNumInitialAssignments() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createKineticLaw(self):
    m = libsbml.Model(2,2)
    p = m.createReaction()
    kl = m.createKineticLaw()
    self.assertTrue( p.isSetKineticLaw() == True )
    self.assertTrue( (kl).getLevel() == 2 )
    self.assertTrue( (kl).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createKineticLawParameters(self):
    m = libsbml.Model(2,2)
    r = m.createReaction()
    kl = m.createKineticLaw()
    p = m.createKineticLawParameter()
    self.assertTrue( r.isSetKineticLaw() == True )
    self.assertTrue( kl.getNumParameters() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createModifier(self):
    m = libsbml.Model(2,2)
    p = m.createReaction()
    sr = m.createModifier()
    self.assertTrue( p.getNumModifiers() == 1 )
    self.assertTrue( (sr).getLevel() == 2 )
    self.assertTrue( (sr).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createParameter(self):
    m = libsbml.Model(2,2)
    p = m.createParameter()
    self.assertTrue( m.getNumParameters() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createProduct(self):
    m = libsbml.Model(2,2)
    p = m.createReaction()
    sr = m.createProduct()
    self.assertTrue( p.getNumProducts() == 1 )
    self.assertTrue( (sr).getLevel() == 2 )
    self.assertTrue( (sr).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createReactant(self):
    m = libsbml.Model(2,2)
    p = m.createReaction()
    sr = m.createReactant()
    self.assertTrue( p.getNumReactants() == 1 )
    self.assertTrue( (sr).getLevel() == 2 )
    self.assertTrue( (sr).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createReaction(self):
    m = libsbml.Model(2,2)
    p = m.createReaction()
    self.assertTrue( m.getNumReactions() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createRule(self):
    m = libsbml.Model(2,2)
    p = m.createAssignmentRule()
    self.assertTrue( m.getNumRules() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createSpecies(self):
    m = libsbml.Model(2,2)
    p = m.createSpecies()
    self.assertTrue( m.getNumSpecies() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createSpeciesType(self):
    m = libsbml.Model(2,2)
    p = m.createSpeciesType()
    self.assertTrue( m.getNumSpeciesTypes() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createUnit(self):
    m = libsbml.Model(2,2)
    p = m.createUnitDefinition()
    u = m.createUnit()
    self.assertTrue( p.getNumUnits() == 1 )
    self.assertTrue( (u).getLevel() == 2 )
    self.assertTrue( (u).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_createUnitDefinition(self):
    m = libsbml.Model(2,2)
    p = m.createUnitDefinition()
    self.assertTrue( m.getNumUnitDefinitions() == 1 )
    self.assertTrue( (p).getLevel() == 2 )
    self.assertTrue( (p).getVersion() == 2 )
    _dummyList = [ m ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_setId1(self):
    id =  "1e1";
    i = self.M.setId(id)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_ATTRIBUTE_VALUE )
    self.assertEqual( False, self.M.isSetId() )
    pass  

  def test_Model_setId2(self):
    id =  "e1";
    i = self.M.setId(id)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue(( id == self.M.getId() ))
    self.assertEqual( True, self.M.isSetId() )
    i = self.M.setId("")
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetId() )
    pass  

  def test_Model_setId3(self):
    id =  "e1";
    i = self.M.setId(id)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue(( id == self.M.getId() ))
    self.assertEqual( True, self.M.isSetId() )
    i = self.M.unsetId()
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetId() )
    pass  

  def test_Model_setModelHistory1(self):
    self.M.setMetaId("_001")
    mh = libsbml.ModelHistory()
    i = self.M.setModelHistory(mh)
    self.assertTrue( i == libsbml.LIBSBML_INVALID_OBJECT )
    self.assertEqual( False, self.M.isSetModelHistory() )
    i = self.M.unsetModelHistory()
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetModelHistory() )
    _dummyList = [ mh ]; _dummyList[:] = []; del _dummyList
    pass  

  def test_Model_setModelHistory2(self):
    self.M.setMetaId("_001")
    i = self.M.setModelHistory(None)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetModelHistory() )
    i = self.M.unsetModelHistory()
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetModelHistory() )
    pass  

  def test_Model_setName1(self):
    name =  "3Set_k2";
    i = self.M.setName(name)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( True, self.M.isSetName() )
    pass  

  def test_Model_setName2(self):
    name =  "Set k2";
    i = self.M.setName(name)
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertTrue(( name == self.M.getName() ))
    self.assertEqual( True, self.M.isSetName() )
    i = self.M.unsetName()
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetName() )
    pass  

  def test_Model_setName3(self):
    i = self.M.setName("")
    self.assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS )
    self.assertEqual( False, self.M.isSetName() )
    pass  

  def test_Model_setName4(self):
    m = libsbml.Model(1,2)
    i = m.setName( "11dd")
    self.assertTrue( i == libsbml.LIBSBML_INVALID_ATTRIBUTE_VALUE )
    self.assertEqual( False, m.isSetName() )
    pass  

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestModel_newSetters))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)

