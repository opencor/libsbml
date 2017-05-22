///  @file    TestEvent.cs
///  @brief   SBML Event unit tests
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
///  src/sbml/test/TestEvent.c
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

  public class TestEvent {
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

    private Event E;

    public void setUp()
    {
      E = new  Event(2,4);
      if (E == null);
      {
      }
    }

    public void tearDown()
    {
      E = null;
    }

    public void test_Event_create()
    {
      assertTrue( E.getTypeCode() == libsbml.SBML_EVENT );
      assertTrue( E.getMetaId() == "" );
      assertTrue( E.getNotes() == null );
      assertTrue( E.getAnnotation() == null );
      assertTrue( E.getId() == "" );
      assertTrue( E.getName() == "" );
      assertEquals(E.getTrigger(),null);
      assertEquals(E.getDelay(),null);
      assertTrue( E.getTimeUnits() == "" );
      assertEquals( false, E.isSetId() );
      assertEquals( false, E.isSetTrigger() );
      assertEquals( false, E.isSetDelay() );
      assertEquals( true, E.isSetUseValuesFromTriggerTime() );
      assertTrue( E.getNumEventAssignments() == 0 );
    }

    public void test_Event_createWithNS()
    {
      XMLNamespaces xmlns = new  XMLNamespaces();
      xmlns.add( "http://www.sbml.org", "testsbml");
      SBMLNamespaces sbmlns = new  SBMLNamespaces(2,4);
      sbmlns.addNamespaces(xmlns);
      Event object1 = new  Event(sbmlns);
      assertTrue( object1.getTypeCode() == libsbml.SBML_EVENT );
      assertTrue( object1.getMetaId() == "" );
      assertTrue( object1.getNotes() == null );
      assertTrue( object1.getAnnotation() == null );
      assertTrue( object1.getLevel() == 2 );
      assertTrue( object1.getVersion() == 4 );
      assertTrue( object1.getNamespaces() != null );
      assertTrue( object1.getNamespaces().getLength() == 2 );
      object1 = null;
    }

    public void test_Event_free_NULL()
    {
    }

    public void test_Event_full()
    {
      ASTNode math1 = libsbml.parseFormula("0");
      Trigger trigger = new  Trigger(2,4);
      ASTNode math = libsbml.parseFormula("0");
      Event e = new  Event(2,4);
      EventAssignment ea = new  EventAssignment(2,4);
      ea.setVariable( "k");
      ea.setMath(math);
      trigger.setMath(math1);
      e.setTrigger(trigger);
      e.setId( "e1");
      e.setName( "Set k2 to zero when P1 <= t");
      e.addEventAssignment(ea);
      assertTrue( e.getNumEventAssignments() == 1 );
      assertNotEquals(e.getEventAssignment(0),ea);
      math = null;
      e = null;
    }

    public void test_Event_removeEventAssignment()
    {
      EventAssignment o1, o2, o3;
      o1 = E.createEventAssignment();
      o2 = E.createEventAssignment();
      o3 = E.createEventAssignment();
      o3.setVariable("test");
      assertTrue( E.removeEventAssignment(0) == o1 );
      assertTrue( E.getNumEventAssignments() == 2 );
      assertTrue( E.removeEventAssignment(0) == o2 );
      assertTrue( E.getNumEventAssignments() == 1 );
      assertTrue( E.removeEventAssignment("test") == o3 );
      assertTrue( E.getNumEventAssignments() == 0 );
      o1 = null;
      o2 = null;
      o3 = null;
    }

    public void test_Event_setDelay()
    {
      ASTNode math1 = libsbml.parseFormula("0");
      Delay Delay = new  Delay(2,4);
      Delay.setMath(math1);
      E.setDelay(Delay);
      assertNotEquals(E.getDelay(),null);
      assertEquals( true, E.isSetDelay() );
      if (E.getDelay() == Delay);
      {
      }
      E.setDelay(E.getDelay());
      assertNotEquals(E.getDelay(),Delay);
      E.setDelay(null);
      assertEquals( false, E.isSetDelay() );
      if (E.getDelay() != null);
      {
      }
    }

    public void test_Event_setId()
    {
      string id =  "e1";
      E.setId(id);
      assertTrue(( id == E.getId() ));
      assertEquals( true, E.isSetId() );
      if (E.getId() == id);
      {
      }
      E.setId(E.getId());
      assertTrue(( id == E.getId() ));
      E.setId("");
      assertEquals( false, E.isSetId() );
      if (E.getId() != null);
      {
      }
    }

    public void test_Event_setName()
    {
      string name =  "Set_k2";
      E.setName(name);
      assertTrue(( name == E.getName() ));
      assertEquals( true, E.isSetName() );
      if (E.getName() == name);
      {
      }
      E.setName(E.getName());
      assertTrue(( name == E.getName() ));
      E.setName("");
      assertEquals( false, E.isSetName() );
      if (E.getName() != null);
      {
      }
    }

    public void test_Event_setTimeUnits()
    {
      Event E1 = new  Event(2,1);
      string units =  "second";
      E1.setTimeUnits(units);
      assertTrue(( units == E1.getTimeUnits() ));
      assertEquals( true, E1.isSetTimeUnits() );
      if (E1.getTimeUnits() == units);
      {
      }
      E1.setTimeUnits(E1.getTimeUnits());
      assertTrue(( units == E1.getTimeUnits() ));
      E1.setTimeUnits("");
      assertEquals( false, E1.isSetTimeUnits() );
      if (E1.getTimeUnits() != null);
      {
      }
      E1 = null;
    }

    public void test_Event_setTrigger()
    {
      ASTNode math1 = libsbml.parseFormula("0");
      Trigger trigger = new  Trigger(2,4);
      trigger.setMath(math1);
      E.setTrigger(trigger);
      assertNotEquals(E.getTrigger(),null);
      assertEquals( true, E.isSetTrigger() );
      if (E.getTrigger() == trigger);
      {
      }
      E.setTrigger(E.getTrigger());
      assertNotEquals(E.getTrigger(),trigger);
      E.setTrigger(null);
      assertEquals( false, E.isSetTrigger() );
      if (E.getTrigger() != null);
      {
      }
    }

    public void test_Event_setUseValuesFromTriggerTime()
    {
      Event object1 = new  Event(2,4);
      object1.setUseValuesFromTriggerTime(false);
      assertTrue( object1.getUseValuesFromTriggerTime() == false );
      object1.setUseValuesFromTriggerTime(true);
      assertTrue( object1.getUseValuesFromTriggerTime() == true );
      object1 = null;
    }

  }
}
