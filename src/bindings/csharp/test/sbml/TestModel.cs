///  @file    TestModel.cs
///  @brief   SBML Model unit tests
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
///  src/sbml/test/TestModel.c
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

  public class TestModel {
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

    private Model M;

    public void setUp()
    {
      M = new  Model(2,4);
      if (M == null);
      {
      }
    }

    public void tearDown()
    {
      M = null;
    }

    public void test_KineticLaw_getParameterById()
    {
      Parameter k1 = new  Parameter(2,4);
      Parameter k2 = new  Parameter(2,4);
      k1.setId( "k1");
      k2.setId( "k2");
      k1.setValue(3.14);
      k2.setValue(2.72);
      M.addParameter(k1);
      M.addParameter(k2);
      Reaction r1 = new  Reaction(2,4);
      r1.setId( "reaction_1" );
      KineticLaw kl = new  KineticLaw(2,4);
      kl.setFormula( "k1 * X0");
      Parameter k3 = new  Parameter(2,4);
      Parameter k4 = new  Parameter(2,4);
      k3.setId( "k1");
      k4.setId( "k2");
      k3.setValue(2.72);
      k4.setValue(3.14);
      kl.addParameter(k3);
      kl.addParameter(k4);
      r1.setKineticLaw(kl);
      M.addReaction(r1);
      KineticLaw kl1 = M.getReaction(0).getKineticLaw();
      assertNotEquals(kl1.getParameter( "k1" ),k3);
      assertNotEquals(kl1.getParameter( "k1" ),k1);
      assertNotEquals(kl1.getParameter( "k2" ),k4);
      assertEquals(kl1.getParameter( "k3" ),null);
    }

    public void test_Model_addCompartment()
    {
      Compartment c = new  Compartment(2,4);
      c.setId( "c");
      M.addCompartment(c);
      assertTrue( M.getNumCompartments() == 1 );
    }

    public void test_Model_addParameter()
    {
      Parameter p = new  Parameter(2,4);
      p.setId( "p");
      M.addParameter(p);
      assertTrue( M.getNumParameters() == 1 );
    }

    public void test_Model_addReaction()
    {
      Reaction r = new  Reaction(2,4);
      r.setId( "r");
      M.addReaction(r);
      assertTrue( M.getNumReactions() == 1 );
    }

    public void test_Model_addRules()
    {
      Rule r1 = new  AlgebraicRule(2,4);
      Rule r2 = new  AssignmentRule(2,4);
      Rule r3 = new  RateRule(2,4);
      r2.setVariable( "r2");
      r3.setVariable( "r3");
      r1.setMath(libsbml.parseFormula("2"));
      r2.setMath(libsbml.parseFormula("2"));
      r3.setMath(libsbml.parseFormula("2"));
      M.addRule(r1);
      M.addRule(r2);
      M.addRule(r3);
      assertTrue( M.getNumRules() == 3 );
    }

    public void test_Model_addSpecies()
    {
      Species s = new  Species(2,4);
      s.setId( "s");
      s.setCompartment( "c");
      M.addSpecies(s);
      assertTrue( M.getNumSpecies() == 1 );
    }

    public void test_Model_add_get_Event()
    {
      Event e1 = new  Event(2,4);
      Event e2 = new  Event(2,4);
      Trigger t = new  Trigger(2,4);
      t.setMath(libsbml.parseFormula("true"));
      e1.setTrigger(t);
      e2.setTrigger(t);
      e1.createEventAssignment();
      e2.createEventAssignment();
      M.addEvent(e1);
      M.addEvent(e2);
      assertTrue( M.getNumEvents() == 2 );
      assertNotEquals(M.getEvent(0),e1);
      assertNotEquals(M.getEvent(1),e2);
      assertEquals(M.getEvent(2),null);
    }

    public void test_Model_add_get_FunctionDefinitions()
    {
      FunctionDefinition fd1 = new  FunctionDefinition(2,4);
      FunctionDefinition fd2 = new  FunctionDefinition(2,4);
      fd1.setId( "fd1");
      fd2.setId( "fd2");
      fd1.setMath(libsbml.parseFormula("2"));
      fd2.setMath(libsbml.parseFormula("2"));
      M.addFunctionDefinition(fd1);
      M.addFunctionDefinition(fd2);
      assertTrue( M.getNumFunctionDefinitions() == 2 );
      assertNotEquals(M.getFunctionDefinition(0),fd1);
      assertNotEquals(M.getFunctionDefinition(1),fd2);
      assertEquals(M.getFunctionDefinition(2),null);
    }

    public void test_Model_add_get_UnitDefinitions()
    {
      UnitDefinition ud1 = new  UnitDefinition(2,4);
      UnitDefinition ud2 = new  UnitDefinition(2,4);
      ud1.setId( "ud1");
      ud2.setId( "ud2");
      ud1.createUnit();
      ud2.createUnit();
      M.addUnitDefinition(ud1);
      M.addUnitDefinition(ud2);
      assertTrue( M.getNumUnitDefinitions() == 2 );
      assertNotEquals(M.getUnitDefinition(0),ud1);
      assertNotEquals(M.getUnitDefinition(1),ud2);
      assertEquals(M.getUnitDefinition(2),null);
    }

    public void test_Model_conversionFactor()
    {
      assertEquals( false, M.isSetConversionFactor() );
      int ret = M.unsetConversionFactor();
      assertTrue( ret == libsbml.LIBSBML_UNEXPECTED_ATTRIBUTE );
    }

    public void test_Model_create()
    {
      assertTrue( M.getTypeCode() == libsbml.SBML_MODEL );
      assertTrue( M.getMetaId() == "" );
      assertTrue( M.getNotes() == null );
      assertTrue( M.getAnnotation() == null );
      assertTrue( M.getId() == "" );
      assertTrue( M.getName() == "" );
      assertEquals( false, M.isSetId() );
      assertEquals( false, M.isSetName() );
      assertTrue( M.getNumUnitDefinitions() == 0 );
      assertTrue( M.getNumCompartments() == 0 );
      assertTrue( M.getNumSpecies() == 0 );
      assertTrue( M.getNumParameters() == 0 );
      assertTrue( M.getNumReactions() == 0 );
    }

    public void test_Model_createAlgebraicRule()
    {
      Rule ar = M.createAlgebraicRule();
      assertTrue( ar != null );
      assertTrue( M.getNumRules() == 1 );
      assertEquals(M.getRule(0),ar);
    }

    public void test_Model_createAssignmentRule()
    {
      Rule ar = M.createAssignmentRule();
      assertTrue( ar != null );
      assertTrue( M.getNumRules() == 1 );
      assertEquals(M.getRule(0),ar);
    }

    public void test_Model_createCompartment()
    {
      Compartment c = M.createCompartment();
      assertTrue( c != null );
      assertTrue( M.getNumCompartments() == 1 );
      assertTrue( M.getCompartment(0) == c );
    }

    public void test_Model_createCompartmentType()
    {
      CompartmentType c = M.createCompartmentType();
      assertTrue( c != null );
      assertTrue( M.getNumCompartmentTypes() == 1 );
      assertEquals(M.getCompartmentType(0),c);
    }

    public void test_Model_createConstraint()
    {
      Constraint c = M.createConstraint();
      assertTrue( c != null );
      assertTrue( M.getNumConstraints() == 1 );
      assertEquals(M.getConstraint(0),c);
    }

    public void test_Model_createEvent()
    {
      Event e = M.createEvent();
      assertTrue( e != null );
      assertTrue( M.getNumEvents() == 1 );
      assertEquals(M.getEvent(0),e);
    }

    public void test_Model_createEventAssignment()
    {
      Event e;
      EventAssignment ea;
      M.createEvent();
      M.createEvent();
      ea = M.createEventAssignment();
      assertTrue( ea != null );
      assertTrue( M.getNumEvents() == 2 );
      e = M.getEvent(1);
      assertTrue( e.getNumEventAssignments() == 1 );
      assertEquals(e.getEventAssignment(0),ea);
    }

    public void test_Model_createEventAssignment_noEvent()
    {
      assertTrue( M.getNumEvents() == 0 );
      assertTrue( M.createEventAssignment() == null );
    }

    public void test_Model_createFunctionDefinition()
    {
      FunctionDefinition fd = M.createFunctionDefinition();
      assertTrue( fd != null );
      assertTrue( M.getNumFunctionDefinitions() == 1 );
      assertEquals(M.getFunctionDefinition(0),fd);
    }

    public void test_Model_createInitialAssignment()
    {
      InitialAssignment c = M.createInitialAssignment();
      assertTrue( c != null );
      assertTrue( M.getNumInitialAssignments() == 1 );
      assertEquals(M.getInitialAssignment(0),c);
    }

    public void test_Model_createKineticLaw()
    {
      Reaction r;
      KineticLaw kl;
      M.createReaction();
      M.createReaction();
      kl = M.createKineticLaw();
      assertTrue( kl != null );
      assertTrue( M.getNumReactions() == 2 );
      r = M.getReaction(0);
      assertEquals(r.getKineticLaw(),null);
      r = M.getReaction(1);
      assertEquals(r.getKineticLaw(),kl);
    }

    public void test_Model_createKineticLawParameter()
    {
      Reaction r;
      KineticLaw kl;
      Parameter p;
      M.createReaction();
      M.createReaction();
      M.createKineticLaw();
      p = M.createKineticLawParameter();
      assertTrue( M.getNumReactions() == 2 );
      r = M.getReaction(0);
      assertEquals(r.getKineticLaw(),null);
      r = M.getReaction(1);
      assertNotEquals(r.getKineticLaw(),null);
      kl = r.getKineticLaw();
      assertTrue( kl.getNumParameters() == 1 );
      assertEquals(kl.getParameter(0),p);
    }

    public void test_Model_createKineticLawParameter_noKineticLaw()
    {
      Reaction r;
      r = M.createReaction();
      assertEquals(r.getKineticLaw(),null);
      assertTrue( M.createKineticLawParameter() == null );
    }

    public void test_Model_createKineticLawParameter_noReaction()
    {
      assertTrue( M.getNumReactions() == 0 );
      assertTrue( M.createKineticLawParameter() == null );
    }

    public void test_Model_createKineticLaw_alreadyExists()
    {
      Reaction r;
      KineticLaw kl;
      r = M.createReaction();
      kl = M.createKineticLaw();
      assertEquals(r.getKineticLaw(),kl);
    }

    public void test_Model_createKineticLaw_noReaction()
    {
      assertTrue( M.getNumReactions() == 0 );
      assertTrue( M.createKineticLaw() == null );
    }

    public void test_Model_createModifier()
    {
      Reaction r;
      ModifierSpeciesReference msr;
      M.createReaction();
      M.createReaction();
      msr = M.createModifier();
      assertTrue( msr != null );
      assertTrue( M.getNumReactions() == 2 );
      r = M.getReaction(1);
      assertTrue( r.getNumModifiers() == 1 );
      assertEquals(r.getModifier(0),msr);
    }

    public void test_Model_createModifier_noReaction()
    {
      assertTrue( M.getNumReactions() == 0 );
      assertTrue( M.createModifier() == null );
    }

    public void test_Model_createParameter()
    {
      Parameter p = M.createParameter();
      assertTrue( p != null );
      assertTrue( M.getNumParameters() == 1 );
      assertEquals(M.getParameter(0),p);
    }

    public void test_Model_createProduct()
    {
      Reaction r;
      SpeciesReference sr;
      M.createReaction();
      M.createReaction();
      sr = M.createProduct();
      assertTrue( sr != null );
      assertTrue( M.getNumReactions() == 2 );
      r = M.getReaction(1);
      assertTrue( r.getNumProducts() == 1 );
      assertEquals(r.getProduct(0),sr);
    }

    public void test_Model_createProduct_noReaction()
    {
      assertTrue( M.getNumReactions() == 0 );
      assertTrue( M.createProduct() == null );
    }

    public void test_Model_createRateRule()
    {
      Rule rr = M.createRateRule();
      assertTrue( rr != null );
      assertTrue( M.getNumRules() == 1 );
      assertEquals(M.getRule(0),rr);
    }

    public void test_Model_createReactant()
    {
      Reaction r;
      SpeciesReference sr;
      M.createReaction();
      M.createReaction();
      sr = M.createReactant();
      assertTrue( sr != null );
      assertTrue( M.getNumReactions() == 2 );
      r = M.getReaction(1);
      assertTrue( r.getNumReactants() == 1 );
      assertEquals(r.getReactant(0),sr);
    }

    public void test_Model_createReactant_noReaction()
    {
      assertTrue( M.getNumReactions() == 0 );
      assertTrue( M.createReactant() == null );
    }

    public void test_Model_createReaction()
    {
      Reaction r = M.createReaction();
      assertTrue( r != null );
      assertTrue( M.getNumReactions() == 1 );
      assertEquals(M.getReaction(0),r);
    }

    public void test_Model_createSpecies()
    {
      Species s = M.createSpecies();
      assertTrue( s != null );
      assertTrue( M.getNumSpecies() == 1 );
      assertTrue( M.getSpecies(0) == s );
    }

    public void test_Model_createSpeciesType()
    {
      SpeciesType c = M.createSpeciesType();
      assertTrue( c != null );
      assertTrue( M.getNumSpeciesTypes() == 1 );
      assertEquals(M.getSpeciesType(0),c);
    }

    public void test_Model_createUnit()
    {
      UnitDefinition ud;
      Unit u;
      M.createUnitDefinition();
      M.createUnitDefinition();
      u = M.createUnit();
      assertTrue( u != null );
      assertTrue( M.getNumUnitDefinitions() == 2 );
      ud = M.getUnitDefinition(1);
      assertTrue( ud.getNumUnits() == 1 );
      assertEquals(ud.getUnit(0),u);
    }

    public void test_Model_createUnitDefinition()
    {
      UnitDefinition ud = M.createUnitDefinition();
      assertTrue( ud != null );
      assertTrue( M.getNumUnitDefinitions() == 1 );
      assertEquals(M.getUnitDefinition(0),ud);
    }

    public void test_Model_createUnit_noUnitDefinition()
    {
      assertTrue( M.getNumUnitDefinitions() == 0 );
      assertTrue( M.createUnit() == null );
    }

    public void test_Model_createWithNS()
    {
      XMLNamespaces xmlns = new  XMLNamespaces();
      xmlns.add( "http://www.sbml.org", "testsbml");
      SBMLNamespaces sbmlns = new  SBMLNamespaces(2,1);
      sbmlns.addNamespaces(xmlns);
      Model object1 = new  Model(sbmlns);
      assertTrue( object1.getTypeCode() == libsbml.SBML_MODEL );
      assertTrue( object1.getMetaId() == "" );
      assertTrue( object1.getNotes() == null );
      assertTrue( object1.getAnnotation() == null );
      assertTrue( object1.getLevel() == 2 );
      assertTrue( object1.getVersion() == 1 );
      assertTrue( object1.getNamespaces() != null );
      assertTrue( object1.getNamespaces().getLength() == 2 );
      object1 = null;
    }

    public void test_Model_free_NULL()
    {
    }

    public void test_Model_getCompartment()
    {
      Compartment c1 = new  Compartment(2,4);
      Compartment c2 = new  Compartment(2,4);
      c1.setId( "A");
      c2.setId( "B");
      M.addCompartment(c1);
      M.addCompartment(c2);
      assertTrue( M.getNumCompartments() == 2 );
      c1 = M.getCompartment(0);
      c2 = M.getCompartment(1);
      assertTrue((  "A" == c1.getId() ));
      assertTrue((  "B" == c2.getId() ));
    }

    public void test_Model_getCompartmentById()
    {
      Compartment c1 = new  Compartment(2,4);
      Compartment c2 = new  Compartment(2,4);
      c1.setId( "A" );
      c2.setId( "B" );
      M.addCompartment(c1);
      M.addCompartment(c2);
      assertTrue( M.getNumCompartments() == 2 );
      assertTrue( M.getCompartment( "A" ) != c1 );
      assertTrue( M.getCompartment( "B" ) != c2 );
      assertTrue( M.getCompartment( "C" ) == null );
    }

    public void test_Model_getEventById()
    {
      Event e1 = new  Event(2,4);
      Event e2 = new  Event(2,4);
      Trigger t = new  Trigger(2,4);
      t.setMath(libsbml.parseFormula("true"));
      e1.setTrigger(t);
      e2.setTrigger(t);
      e1.createEventAssignment();
      e2.createEventAssignment();
      e1.setId( "e1" );
      e2.setId( "e2" );
      M.addEvent(e1);
      M.addEvent(e2);
      assertTrue( M.getNumEvents() == 2 );
      assertNotEquals(M.getEvent( "e1" ),e1);
      assertNotEquals(M.getEvent( "e2" ),e2);
      assertEquals(M.getEvent( "e3" ),null);
    }

    public void test_Model_getFunctionDefinitionById()
    {
      FunctionDefinition fd1 = new  FunctionDefinition(2,4);
      FunctionDefinition fd2 = new  FunctionDefinition(2,4);
      fd1.setId( "sin" );
      fd2.setId( "cos" );
      fd1.setMath(libsbml.parseFormula("2"));
      fd2.setMath(libsbml.parseFormula("2"));
      M.addFunctionDefinition(fd1);
      M.addFunctionDefinition(fd2);
      assertTrue( M.getNumFunctionDefinitions() == 2 );
      assertNotEquals(M.getFunctionDefinition( "sin" ),fd1);
      assertNotEquals(M.getFunctionDefinition( "cos" ),fd2);
      assertEquals(M.getFunctionDefinition( "tan" ),null);
    }

    public void test_Model_getNumSpeciesWithBoundaryCondition()
    {
      Species s1 = new  Species(2,4);
      Species s2 = new  Species(2,4);
      Species s3 = new  Species(2,4);
      s1.setId( "s1");
      s2.setId( "s2");
      s3.setId( "s3");
      s1.setCompartment( "c1");
      s2.setCompartment( "c2");
      s3.setCompartment( "c3");
      s1.setBoundaryCondition(true);
      s2.setBoundaryCondition(false);
      s3.setBoundaryCondition(true);
      assertTrue( M.getNumSpecies() == 0 );
      assertTrue( M.getNumSpeciesWithBoundaryCondition() == 0 );
      M.addSpecies(s1);
      assertTrue( M.getNumSpecies() == 1 );
      assertTrue( M.getNumSpeciesWithBoundaryCondition() == 1 );
      M.addSpecies(s2);
      assertTrue( M.getNumSpecies() == 2 );
      assertTrue( M.getNumSpeciesWithBoundaryCondition() == 1 );
      M.addSpecies(s3);
      assertTrue( M.getNumSpecies() == 3 );
      assertTrue( M.getNumSpeciesWithBoundaryCondition() == 2 );
    }

    public void test_Model_getParameter()
    {
      Parameter p1 = new  Parameter(2,4);
      Parameter p2 = new  Parameter(2,4);
      p1.setId( "Km1");
      p2.setId( "Km2");
      M.addParameter(p1);
      M.addParameter(p2);
      assertTrue( M.getNumParameters() == 2 );
      p1 = M.getParameter(0);
      p2 = M.getParameter(1);
      assertTrue((  "Km1" == p1.getId() ));
      assertTrue((  "Km2" == p2.getId() ));
    }

    public void test_Model_getParameterById()
    {
      Parameter p1 = new  Parameter(2,4);
      Parameter p2 = new  Parameter(2,4);
      p1.setId( "Km1" );
      p2.setId( "Km2" );
      M.addParameter(p1);
      M.addParameter(p2);
      assertTrue( M.getNumParameters() == 2 );
      assertNotEquals(M.getParameter( "Km1" ),p1);
      assertNotEquals(M.getParameter( "Km2" ),p2);
      assertEquals(M.getParameter( "Km3" ),null);
    }

    public void test_Model_getReaction()
    {
      Reaction r1 = new  Reaction(2,4);
      Reaction r2 = new  Reaction(2,4);
      r1.setId( "reaction_1");
      r2.setId( "reaction_2");
      M.addReaction(r1);
      M.addReaction(r2);
      assertTrue( M.getNumReactions() == 2 );
      r1 = M.getReaction(0);
      r2 = M.getReaction(1);
      assertTrue((  "reaction_1" == r1.getId() ));
      assertTrue((  "reaction_2" == r2.getId() ));
    }

    public void test_Model_getReactionById()
    {
      Reaction r1 = new  Reaction(2,4);
      Reaction r2 = new  Reaction(2,4);
      r1.setId( "reaction_1" );
      r2.setId( "reaction_2" );
      M.addReaction(r1);
      M.addReaction(r2);
      assertTrue( M.getNumReactions() == 2 );
      assertNotEquals(M.getReaction( "reaction_1" ),r1);
      assertNotEquals(M.getReaction( "reaction_2" ),r2);
      assertEquals(M.getReaction( "reaction_3" ),null);
    }

    public void test_Model_getRules()
    {
      Rule ar = new  AlgebraicRule(2,4);
      Rule scr = new  AssignmentRule(2,4);
      Rule cvr = new  AssignmentRule(2,4);
      Rule pr = new  AssignmentRule(2,4);
      scr.setVariable( "r2");
      cvr.setVariable( "r3");
      pr.setVariable( "r4");
      ar.setFormula( "x + 1"         );
      scr.setFormula( "k * t/(1 + k)" );
      cvr.setFormula( "0.10 * t"      );
      pr.setFormula( "k3/k2"         );
      M.addRule(ar);
      M.addRule(scr);
      M.addRule(cvr);
      M.addRule(pr);
      assertTrue( M.getNumRules() == 4 );
      ar = M.getRule(0);
      scr = M.getRule(1);
      cvr = M.getRule(2);
      pr = M.getRule(3);
      assertTrue((  "x + 1"         == ar.getFormula() ));
      assertTrue((  "k * t/(1 + k)" == scr.getFormula() ));
      assertTrue((  "0.10 * t"      == cvr.getFormula() ));
      assertTrue((  "k3/k2"         == pr.getFormula() ));
    }

    public void test_Model_getSpecies()
    {
      Species s1 = new  Species(2,4);
      Species s2 = new  Species(2,4);
      s1.setId( "Glucose"     );
      s2.setId( "Glucose_6_P" );
      s1.setCompartment( "c");
      s2.setCompartment( "c");
      M.addSpecies(s1);
      M.addSpecies(s2);
      assertTrue( M.getNumSpecies() == 2 );
      s1 = M.getSpecies(0);
      s2 = M.getSpecies(1);
      assertTrue((  "Glucose"      == s1.getId() ));
      assertTrue((  "Glucose_6_P"  == s2.getId() ));
    }

    public void test_Model_getSpeciesById()
    {
      Species s1 = new  Species(2,4);
      Species s2 = new  Species(2,4);
      s1.setId( "Glucose"     );
      s2.setId( "Glucose_6_P" );
      s1.setCompartment( "c");
      s2.setCompartment( "c");
      M.addSpecies(s1);
      M.addSpecies(s2);
      assertTrue( M.getNumSpecies() == 2 );
      assertTrue( M.getSpecies( "Glucose"    ) != s1 );
      assertTrue( M.getSpecies( "Glucose_6_P") != s2 );
      assertTrue( M.getSpecies( "Glucose2"   ) == null );
    }

    public void test_Model_getSpeciesReferenceById()
    {
      Reaction r1 = new  Reaction(2,4);
      r1.setId( "r1");
      SpeciesReference sr = r1.createReactant();
      sr.setId( "s1");
      M.addReaction(r1);
      assertTrue( M.getNumReactions() == 1 );
      assertNotEquals(M.getSpeciesReference( "s1" ),sr);
    }

    public void test_Model_getUnitDefinition()
    {
      UnitDefinition ud1 = new  UnitDefinition(2,4);
      UnitDefinition ud2 = new  UnitDefinition(2,4);
      ud1.setId( "mmls"   );
      ud2.setId( "volume" );
      ud1.createUnit();
      ud2.createUnit();
      M.addUnitDefinition(ud1);
      M.addUnitDefinition(ud2);
      assertTrue( M.getNumUnitDefinitions() == 2 );
      ud1 = M.getUnitDefinition(0);
      ud2 = M.getUnitDefinition(1);
      assertTrue((  "mmls"    == ud1.getId() ));
      assertTrue((  "volume"  == ud2.getId() ));
    }

    public void test_Model_getUnitDefinitionById()
    {
      UnitDefinition ud1 = new  UnitDefinition(2,4);
      UnitDefinition ud2 = new  UnitDefinition(2,4);
      ud1.setId( "mmls"   );
      ud2.setId( "volume" );
      ud1.createUnit();
      ud2.createUnit();
      M.addUnitDefinition(ud1);
      M.addUnitDefinition(ud2);
      assertTrue( M.getNumUnitDefinitions() == 2 );
      assertNotEquals(M.getUnitDefinition( "mmls"       ),ud1);
      assertNotEquals(M.getUnitDefinition( "volume"     ),ud2);
      assertEquals(M.getUnitDefinition( "rototillers"),null);
    }

    public void test_Model_removeCompartment()
    {
      Compartment o1, o2, o3;
      o1 = M.createCompartment();
      o2 = M.createCompartment();
      o3 = M.createCompartment();
      o3.setId("test");
      assertTrue( M.removeCompartment(0) == o1 );
      assertTrue( M.getNumCompartments() == 2 );
      assertTrue( M.removeCompartment(0) == o2 );
      assertTrue( M.getNumCompartments() == 1 );
      assertTrue( M.removeCompartment("test") == o3 );
      assertTrue( M.getNumCompartments() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeCompartmentType()
    {
      CompartmentType o1, o2, o3;
      o1 = M.createCompartmentType();
      o2 = M.createCompartmentType();
      o3 = M.createCompartmentType();
      o3.setId("test");
      assertTrue( M.removeCompartmentType(0) == o1 );
      assertTrue( M.getNumCompartmentTypes() == 2 );
      assertTrue( M.removeCompartmentType(0) == o2 );
      assertTrue( M.getNumCompartmentTypes() == 1 );
      assertTrue( M.removeCompartmentType("test") == o3 );
      assertTrue( M.getNumCompartmentTypes() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeConstraint()
    {
      Constraint o1, o2, o3;
      o1 = M.createConstraint();
      o2 = M.createConstraint();
      o3 = M.createConstraint();
      assertTrue( M.removeConstraint(0) == o1 );
      assertTrue( M.getNumConstraints() == 2 );
      assertTrue( M.removeConstraint(0) == o2 );
      assertTrue( M.getNumConstraints() == 1 );
      assertTrue( M.removeConstraint(0) == o3 );
      assertTrue( M.getNumConstraints() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeEvent()
    {
      Event o1, o2, o3;
      o1 = M.createEvent();
      o2 = M.createEvent();
      o3 = M.createEvent();
      o3.setId("test");
      assertTrue( M.removeEvent(0) == o1 );
      assertTrue( M.getNumEvents() == 2 );
      assertTrue( M.removeEvent(0) == o2 );
      assertTrue( M.getNumEvents() == 1 );
      assertTrue( M.removeEvent("test") == o3 );
      assertTrue( M.getNumEvents() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeFunctionDefinition()
    {
      FunctionDefinition o1, o2, o3;
      o1 = M.createFunctionDefinition();
      o2 = M.createFunctionDefinition();
      o3 = M.createFunctionDefinition();
      o3.setId("test");
      assertTrue( M.removeFunctionDefinition(0) == o1 );
      assertTrue( M.getNumFunctionDefinitions() == 2 );
      assertTrue( M.removeFunctionDefinition(0) == o2 );
      assertTrue( M.getNumFunctionDefinitions() == 1 );
      assertTrue( M.removeFunctionDefinition("test") == o3 );
      assertTrue( M.getNumFunctionDefinitions() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeInitialAssignment()
    {
      InitialAssignment o1, o2, o3;
      o1 = M.createInitialAssignment();
      o2 = M.createInitialAssignment();
      o3 = M.createInitialAssignment();
      o3.setSymbol("test");
      assertTrue( M.removeInitialAssignment(0) == o1 );
      assertTrue( M.getNumInitialAssignments() == 2 );
      assertTrue( M.removeInitialAssignment(0) == o2 );
      assertTrue( M.getNumInitialAssignments() == 1 );
      assertTrue( M.removeInitialAssignment("test") == o3 );
      assertTrue( M.getNumInitialAssignments() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeParameter()
    {
      Parameter o1, o2, o3;
      o1 = M.createParameter();
      o2 = M.createParameter();
      o3 = M.createParameter();
      o3.setId("test");
      assertTrue( M.removeParameter(0) == o1 );
      assertTrue( M.getNumParameters() == 2 );
      assertTrue( M.removeParameter(0) == o2 );
      assertTrue( M.getNumParameters() == 1 );
      assertTrue( M.removeParameter("test") == o3 );
      assertTrue( M.getNumParameters() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeReaction()
    {
      Reaction o1, o2, o3;
      o1 = M.createReaction();
      o2 = M.createReaction();
      o3 = M.createReaction();
      o3.setId("test");
      assertTrue( M.removeReaction(0) == o1 );
      assertTrue( M.getNumReactions() == 2 );
      assertTrue( M.removeReaction(0) == o2 );
      assertTrue( M.getNumReactions() == 1 );
      assertTrue( M.removeReaction("test") == o3 );
      assertTrue( M.getNumReactions() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeRule()
    {
      Rule o1, o2, o3;
      o1 = M.createAssignmentRule();
      o2 = M.createAlgebraicRule();
      o3 = M.createRateRule();
      o3.setVariable("test");
      assertTrue( M.removeRule(0) == o1 );
      assertTrue( M.getNumRules() == 2 );
      assertTrue( M.removeRule(0) == o2 );
      assertTrue( M.getNumRules() == 1 );
      assertTrue( M.removeRule("test") == o3 );
      assertTrue( M.getNumRules() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeSpecies()
    {
      Species o1, o2, o3;
      o1 = M.createSpecies();
      o2 = M.createSpecies();
      o3 = M.createSpecies();
      o3.setId("test");
      assertTrue( M.removeSpecies(0) == o1 );
      assertTrue( M.getNumSpecies() == 2 );
      assertTrue( M.removeSpecies(0) == o2 );
      assertTrue( M.getNumSpecies() == 1 );
      assertTrue( M.removeSpecies("test") == o3 );
      assertTrue( M.getNumSpecies() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeSpeciesType()
    {
      SpeciesType o1, o2, o3;
      o1 = M.createSpeciesType();
      o2 = M.createSpeciesType();
      o3 = M.createSpeciesType();
      o3.setId("test");
      assertTrue( M.removeSpeciesType(0) == o1 );
      assertTrue( M.getNumSpeciesTypes() == 2 );
      assertTrue( M.removeSpeciesType(0) == o2 );
      assertTrue( M.getNumSpeciesTypes() == 1 );
      assertTrue( M.removeSpeciesType("test") == o3 );
      assertTrue( M.getNumSpeciesTypes() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_removeUnitDefinition()
    {
      UnitDefinition o1, o2, o3;
      o1 = M.createUnitDefinition();
      o2 = M.createUnitDefinition();
      o3 = M.createUnitDefinition();
      o3.setId("test");
      assertTrue( M.removeUnitDefinition(0) == o1 );
      assertTrue( M.getNumUnitDefinitions() == 2 );
      assertTrue( M.removeUnitDefinition(0) == o2 );
      assertTrue( M.getNumUnitDefinitions() == 1 );
      assertTrue( M.removeUnitDefinition("test") == o3 );
      assertTrue( M.getNumUnitDefinitions() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Model_setId()
    {
      string id =  "Branch";
      M.setId(id);
      assertTrue(( id == M.getId() ));
      assertEquals( true, M.isSetId() );
      if (M.getId() == id);
      {
      }
      M.setId(M.getId());
      assertTrue(( id == M.getId() ));
      M.setId("");
      assertEquals( false, M.isSetId() );
      if (M.getId() != null);
      {
      }
      M.setId(id);
      M.unsetId();
      assertEquals( false, M.isSetId() );
    }

    public void test_Model_setName()
    {
      string name =  "My_Branch_Model";
      M.setName(name);
      assertTrue(( name == M.getName() ));
      assertEquals( true, M.isSetName() );
      if (M.getName() == name);
      {
      }
      M.setName(M.getName());
      assertTrue(( name == M.getName() ));
      M.setName("");
      assertEquals( false, M.isSetName() );
      if (M.getName() != null);
      {
      }
    }

    public void test_Model_setgetModelHistory()
    {
      M.setMetaId("_001");
      ModelHistory history = new  ModelHistory();
      ModelCreator mc = new  ModelCreator();
      Date date = new  Date(2005,12,30,12,15,45,1,2,0);
      mc.setFamilyName( "Keating");
      mc.setGivenName( "Sarah");
      mc.setEmail( "sbml-team@caltech.edu");
      mc.setOrganisation( "UH");
      history.addCreator(mc);
      history.setCreatedDate(date);
      history.setModifiedDate(date);
      assertTrue( M.isSetModelHistory() == false );
      M.setModelHistory(history);
      assertTrue( M.isSetModelHistory() == true );
      ModelCreator newMC = history.getCreator(0);
      assertTrue( newMC != null );
      assertTrue((  "Keating" == newMC.getFamilyName() ));
      assertTrue((  "Sarah" == newMC.getGivenName() ));
      assertTrue((  "sbml-team@caltech.edu" == newMC.getEmail() ));
      assertTrue((  "UH" == newMC.getOrganisation() ));
      M.unsetModelHistory();
      assertTrue( M.isSetModelHistory() == false );
      history = null;
      mc = null;
    }

  }
}

