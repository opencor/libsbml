/*
 * @file    TestL3Unit.java
 * @brief   L3 Unit unit tests
 *
 * @author  Akiya Jouraku (Java conversion)
 * @author  Sarah Keating 
 * 
 * ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
 *
 * DO NOT EDIT THIS FILE.
 *
 * This file was generated automatically by converting the file located at
 * src/sbml/test/TestL3Unit.c
 * using the conversion program dev/utilities/translateTests/translateTests.pl.
 * Any changes made here will be lost the next time the file is regenerated.
 *
 * -----------------------------------------------------------------------------
 * This file is part of libSBML.  Please visit http://sbml.org for more
 * information about SBML, and the latest version of libSBML.
 *
 * Copyright (C) 2020 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. University of Heidelberg, Heidelberg, Germany
 *     3. University College London, London, UK
 *
 * Copyright 2005-2010 California Institute of Technology.
 * Copyright 2002-2005 California Institute of Technology and
 *                     Japan Science and Technology Corporation.
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation.  A copy of the license agreement is provided
 * in the file named "LICENSE.txt" included with this software distribution
 * and also available online as http://sbml.org/software/libsbml/license.html
 * -----------------------------------------------------------------------------
 */

package org.sbml.libsbml.test.sbml;

import org.sbml.libsbml.*;

import java.io.File;
import java.lang.AssertionError;

public class TestL3Unit {

  static void assertTrue(boolean condition) throws AssertionError
  {
    if (condition == true)
    {
      return;
    }
    throw new AssertionError();
  }

  static void assertEquals(Object a, Object b) throws AssertionError
  {
    if ( (a == null) && (b == null) )
    {
      return;
    }
    else if ( (a == null) || (b == null) )
    {
      throw new AssertionError();
    }
    else if (a.equals(b))
    {
      return;
    }

    throw new AssertionError();
  }

  static void assertNotEquals(Object a, Object b) throws AssertionError
  {
    if ( (a == null) && (b == null) )
    {
      throw new AssertionError();
    }
    else if ( (a == null) || (b == null) )
    {
      return;
    }
    else if (a.equals(b))
    {
      throw new AssertionError();
    }
  }

  static void assertEquals(boolean a, boolean b) throws AssertionError
  {
    if ( a == b )
    {
      return;
    }
    throw new AssertionError();
  }

  static void assertNotEquals(boolean a, boolean b) throws AssertionError
  {
    if ( a != b )
    {
      return;
    }
    throw new AssertionError();
  }

  static void assertEquals(int a, int b) throws AssertionError
  {
    if ( a == b )
    {
      return;
    }
    throw new AssertionError();
  }

  static void assertNotEquals(int a, int b) throws AssertionError
  {
    if ( a != b )
    {
      return;
    }
    throw new AssertionError();
  }
  private Unit U;

  public boolean isnan(double x)
  {
    return (x != x);
  }

  public static final int SBML_INT_MAX = 2147483647;
  protected void setUp() throws Exception
  {
    U = new  Unit(3,1);
    if (U == null);
    {
    }
  }

  protected void tearDown() throws Exception
  {
    U = null;
  }

  public void test_L3_Unit_NS()
  {
    assertTrue( U.getNamespaces() != null );
    assertTrue( U.getNamespaces().getLength() == 1 );
    assertTrue(U.getNamespaces().getURI(0).equals(    "http://www.sbml.org/sbml/level3/version1/core"));
  }

  public void test_L3_Unit_create()
  {
    assertTrue( U.getTypeCode() == libsbml.SBML_UNIT );
    assertTrue( U.getMetaId().equals("") == true );
    assertTrue( U.getNotes() == null );
    assertTrue( U.getAnnotation() == null );
    assertTrue( U.getKind() == libsbml.UNIT_KIND_INVALID );
    assertEquals( true, isnan(U.getExponentAsDouble()) );
    assertEquals( true, isnan(U.getMultiplier()) );
    assertTrue( U.getScale() == SBML_INT_MAX );
    assertEquals( false, U.isSetKind() );
    assertEquals( false, U.isSetExponent() );
    assertEquals( false, U.isSetMultiplier() );
    assertEquals( false, U.isSetScale() );
  }

  public void test_L3_Unit_createWithNS()
  {
    XMLNamespaces xmlns = new  XMLNamespaces();
    xmlns.add( "http://www.sbml.org", "testsbml");
    SBMLNamespaces sbmlns = new  SBMLNamespaces(3,1);
    sbmlns.addNamespaces(xmlns);
    Unit u = new  Unit(sbmlns);
    assertTrue( u.getTypeCode() == libsbml.SBML_UNIT );
    assertTrue( u.getMetaId().equals("") == true );
    assertTrue( u.getNotes() == null );
    assertTrue( u.getAnnotation() == null );
    assertTrue( u.getLevel() == 3 );
    assertTrue( u.getVersion() == 1 );
    assertTrue( u.getNamespaces() != null );
    assertTrue( u.getNamespaces().getLength() == 2 );
    assertTrue( u.getKind() == libsbml.UNIT_KIND_INVALID );
    assertEquals( true, isnan(u.getExponentAsDouble()) );
    assertEquals( true, isnan(u.getMultiplier()) );
    assertEquals( false, u.isSetKind() );
    assertEquals( false, u.isSetExponent() );
    assertEquals( false, u.isSetMultiplier() );
    assertEquals( false, u.isSetScale() );
    u = null;
  }

  public void test_L3_Unit_exponent()
  {
    double exponent = 0.2;
    assertEquals( false, U.isSetExponent() );
    assertEquals( true, isnan(U.getExponentAsDouble()) );
    U.setExponent(exponent);
    assertTrue( U.getExponentAsDouble() == exponent );
    assertEquals( true, U.isSetExponent() );
  }

  public void test_L3_Unit_free_NULL()
  {
  }

  public void test_L3_Unit_hasRequiredAttributes()
  {
    Unit u = new  Unit(3,1);
    assertEquals( false, u.hasRequiredAttributes() );
    u.setKind(libsbml.UNIT_KIND_MOLE);
    assertEquals( false, u.hasRequiredAttributes() );
    u.setExponent(0);
    assertEquals( false, u.hasRequiredAttributes() );
    u.setMultiplier(0.45);
    assertEquals( false, u.hasRequiredAttributes() );
    u.setScale(2);
    assertEquals( true, u.hasRequiredAttributes() );
    u = null;
  }

  public void test_L3_Unit_kind()
  {
    String kind =  "mole";
    assertEquals( false, U.isSetKind() );
    U.setKind(libsbml.UnitKind_forName(kind));
    assertTrue( U.getKind() == libsbml.UNIT_KIND_MOLE );
    assertEquals( true, U.isSetKind() );
  }

  public void test_L3_Unit_multiplier()
  {
    double multiplier = 0.2;
    assertEquals( false, U.isSetMultiplier() );
    assertEquals( true, isnan(U.getMultiplier()) );
    U.setMultiplier(multiplier);
    assertTrue( U.getMultiplier() == multiplier );
    assertEquals( true, U.isSetMultiplier() );
  }

  public void test_L3_Unit_scale()
  {
    int scale = 2;
    assertEquals( false, U.isSetScale() );
    assertTrue( U.getScale() == SBML_INT_MAX );
    U.setScale(scale);
    assertTrue( U.getScale() == scale );
    assertEquals( true, U.isSetScale() );
  }

  /**
   * Loads the SWIG-generated libSBML Java module when this class is
   * loaded, or reports a sensible diagnostic message about why it failed.
   */
  static
  {
    String varname;
    String shlibname;

    if (System.getProperty("mrj.version") != null)
    {
      varname = "DYLD_LIBRARY_PATH";    // We're on a Mac.
      shlibname = "libsbmlj.jnilib and/or libsbml.dylib";
    }
    else
    {
      varname = "LD_LIBRARY_PATH";      // We're not on a Mac.
      shlibname = "libsbmlj.so and/or libsbml.so";
    }

    try
    {
      System.loadLibrary("sbmlj");
      // For extra safety, check that the jar file is in the classpath.
      Class.forName("org.sbml.libsbml.libsbml");
    }
    catch (SecurityException e)
    {
      e.printStackTrace();
      System.err.println("Could not load the libSBML library files due to a"+
                         " security exception.\n");
      System.exit(1);
    }
    catch (UnsatisfiedLinkError e)
    {
      e.printStackTrace();
      System.err.println("Error: could not link with the libSBML library files."+
                         " It is likely\nyour " + varname +
                         " environment variable does not include the directories\n"+
                         "containing the " + shlibname + " library files.\n");
      System.exit(1);
    }
    catch (ClassNotFoundException e)
    {
      e.printStackTrace();
      System.err.println("Error: unable to load the file libsbmlj.jar."+
                         " It is likely\nyour -classpath option and CLASSPATH" +
                         " environment variable\n"+
                         "do not include the path to libsbmlj.jar.\n");
      System.exit(1);
    }
  }
}
