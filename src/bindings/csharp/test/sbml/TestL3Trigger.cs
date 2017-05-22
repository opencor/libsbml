///  @file    TestL3Trigger.cs
///  @brief   SBML Trigger unit tests
///  @author  Frank Bergmann (Csharp conversion)
///  @author  Akiya Jouraku (Csharp conversion)
///  @author  Sarah Keating

///
///  ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
///
///  DO NOT EDIT THIS FILE.
///
///  This file was generated automatically by converting the file located at
///  src/sbml/test/TestL3Trigger.c
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

  public class TestL3Trigger {
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

    private Trigger T;

    public void setUp()
    {
      T = new  Trigger(3,1);
      if (T == null);
      {
      }
    }

    public void tearDown()
    {
      T = null;
    }

    public void test_L3Trigger_create()
    {
      assertTrue( T.getTypeCode() == libsbml.SBML_TRIGGER );
      assertTrue( T.getMetaId() == "" );
      assertTrue( T.getNotes() == null );
      assertTrue( T.getAnnotation() == null );
      assertTrue( T.getMath() == null );
      assertTrue( T.getInitialValue() == true );
      assertTrue( T.getPersistent() == true );
      assertTrue( T.isSetInitialValue() == false );
      assertTrue( T.isSetPersistent() == false );
    }

    public void test_L3Trigger_setInitialValue()
    {
      int i = T.setInitialValue(false);
      assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS );
      assertTrue( T.getInitialValue() == false );
      assertTrue( T.isSetInitialValue() == true );
      i = T.setInitialValue(true);
      assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS );
      assertTrue( T.getInitialValue() == true );
      assertTrue( T.isSetInitialValue() == true );
    }

    public void test_L3Trigger_setInitialValue1()
    {
      Trigger t = new  Trigger(2,4);
      int i = t.setInitialValue(false);
      assertTrue( i == libsbml.LIBSBML_UNEXPECTED_ATTRIBUTE );
      assertTrue( T.getInitialValue() == true );
      assertTrue( T.isSetInitialValue() == false );
      t = null;
    }

    public void test_L3Trigger_setPersistent()
    {
      int i = T.setPersistent(false);
      assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS );
      assertTrue( T.getPersistent() == false );
      assertTrue( T.isSetPersistent() == true );
      i = T.setPersistent(true);
      assertTrue( i == libsbml.LIBSBML_OPERATION_SUCCESS );
      assertTrue( T.getPersistent() == true );
      assertTrue( T.isSetPersistent() == true );
    }

    public void test_L3Trigger_setPersistent1()
    {
      Trigger t = new  Trigger(2,4);
      int i = t.setPersistent(false);
      assertTrue( i == libsbml.LIBSBML_UNEXPECTED_ATTRIBUTE );
      assertTrue( T.getPersistent() == true );
      assertTrue( T.isSetPersistent() == false );
      t = null;
    }

  }
}
