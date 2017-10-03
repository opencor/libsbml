///  @file    TestL3Model.cs
///  @brief   L3 Model unit tests
///  @author  Frank Bergmann (Csharp conversion)
///  @author  Akiya Jouraku (Csharp conversion)
///  @author  Sarah Keating
///
///
///  ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
///
///  DO NOT EDIT THIS FILE.
///
///  This file was generated automatically by converting the file located at
///  src/sbml/test/TestL3Model.c
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

  public class TestL3Model {
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
      M = new  Model(3,1);
      if (M == null);
      {
      }
    }

    public void tearDown()
    {
      M = null;
    }

    public void test_L3_Model_NS()
    {
      assertTrue( M.getNamespaces() != null );
      assertTrue( M.getNamespaces().getLength() == 1 );
      assertTrue((     "http://www.sbml.org/sbml/level3/version1/core" == M.getNamespaces().getURI(0) ));
    }

    public void test_L3_Model_areaUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetAreaUnits() );
      M.setAreaUnits(units);
      assertTrue(( units == M.getAreaUnits() ));
      assertEquals( true, M.isSetAreaUnits() );
      if (M.getAreaUnits() == units);
      {
      }
      M.unsetAreaUnits();
      assertEquals( false, M.isSetAreaUnits() );
      if (M.getAreaUnits() != null);
      {
      }
    }

    public void test_L3_Model_conversionFactor()
    {
      string units =  "mole";
      assertEquals( false, M.isSetConversionFactor() );
      M.setConversionFactor(units);
      assertTrue(( units == M.getConversionFactor() ));
      assertEquals( true, M.isSetConversionFactor() );
      if (M.getConversionFactor() == units);
      {
      }
      M.unsetConversionFactor();
      assertEquals( false, M.isSetConversionFactor() );
      if (M.getConversionFactor() != null);
      {
      }
    }

    public void test_L3_Model_create()
    {
      assertTrue( M.getTypeCode() == libsbml.SBML_MODEL );
      assertTrue( M.getMetaId() == "" );
      assertTrue( M.getNotes() == null );
      assertTrue( M.getAnnotation() == null );
      assertTrue( M.getId() == "" );
      assertTrue( M.getName() == "" );
      assertTrue( M.getSubstanceUnits() == "" );
      assertTrue( M.getTimeUnits() == "" );
      assertTrue( M.getVolumeUnits() == "" );
      assertTrue( M.getAreaUnits() == "" );
      assertTrue( M.getLengthUnits() == "" );
      assertTrue( M.getConversionFactor() == "" );
      assertEquals( false, M.isSetId() );
      assertEquals( false, M.isSetName() );
      assertEquals( false, M.isSetSubstanceUnits() );
      assertEquals( false, M.isSetTimeUnits() );
      assertEquals( false, M.isSetVolumeUnits() );
      assertEquals( false, M.isSetAreaUnits() );
      assertEquals( false, M.isSetLengthUnits() );
      assertEquals( false, M.isSetConversionFactor() );
    }

    public void test_L3_Model_createWithNS()
    {
      XMLNamespaces xmlns = new  XMLNamespaces();
      xmlns.add( "http://www.sbml.org", "testsbml");
      SBMLNamespaces sbmlns = new  SBMLNamespaces(3,1);
      sbmlns.addNamespaces(xmlns);
      Model m = new  Model(sbmlns);
      assertTrue( m.getTypeCode() == libsbml.SBML_MODEL );
      assertTrue( m.getMetaId() == "" );
      assertTrue( m.getNotes() == null );
      assertTrue( m.getAnnotation() == null );
      assertTrue( m.getLevel() == 3 );
      assertTrue( m.getVersion() == 1 );
      assertTrue( m.getNamespaces() != null );
      assertTrue( m.getNamespaces().getLength() == 2 );
      assertTrue( m.getId() == "" );
      assertTrue( m.getName() == "" );
      assertTrue( m.getSubstanceUnits() == "" );
      assertTrue( m.getTimeUnits() == "" );
      assertTrue( m.getVolumeUnits() == "" );
      assertTrue( m.getAreaUnits() == "" );
      assertTrue( m.getLengthUnits() == "" );
      assertTrue( m.getConversionFactor() == "" );
      assertEquals( false, m.isSetId() );
      assertEquals( false, m.isSetName() );
      assertEquals( false, m.isSetSubstanceUnits() );
      assertEquals( false, m.isSetTimeUnits() );
      assertEquals( false, m.isSetVolumeUnits() );
      assertEquals( false, m.isSetAreaUnits() );
      assertEquals( false, m.isSetLengthUnits() );
      assertEquals( false, m.isSetConversionFactor() );
      m = null;
    }

    public void test_L3_Model_extentUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetExtentUnits() );
      M.setExtentUnits(units);
      assertTrue(( units == M.getExtentUnits() ));
      assertEquals( true, M.isSetExtentUnits() );
      if (M.getExtentUnits() == units);
      {
      }
      M.unsetExtentUnits();
      assertEquals( false, M.isSetExtentUnits() );
      if (M.getExtentUnits() != null);
      {
      }
    }

    public void test_L3_Model_free_NULL()
    {
    }

    public void test_L3_Model_id()
    {
      string id =  "mitochondria";
      assertEquals( false, M.isSetId() );
      M.setId(id);
      assertTrue(( id == M.getId() ));
      assertEquals( true, M.isSetId() );
      if (M.getId() == id);
      {
      }
      M.unsetId();
      assertEquals( false, M.isSetId() );
      if (M.getId() != null);
      {
      }
    }

    public void test_L3_Model_lengthUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetLengthUnits() );
      M.setLengthUnits(units);
      assertTrue(( units == M.getLengthUnits() ));
      assertEquals( true, M.isSetLengthUnits() );
      if (M.getLengthUnits() == units);
      {
      }
      M.unsetLengthUnits();
      assertEquals( false, M.isSetLengthUnits() );
      if (M.getLengthUnits() != null);
      {
      }
    }

    public void test_L3_Model_name()
    {
      string name =  "My_Favorite_Factory";
      assertEquals( false, M.isSetName() );
      M.setName(name);
      assertTrue(( name == M.getName() ));
      assertEquals( true, M.isSetName() );
      if (M.getName() == name);
      {
      }
      M.unsetName();
      assertEquals( false, M.isSetName() );
      if (M.getName() != null);
      {
      }
    }

    public void test_L3_Model_substanceUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetSubstanceUnits() );
      M.setSubstanceUnits(units);
      assertTrue(( units == M.getSubstanceUnits() ));
      assertEquals( true, M.isSetSubstanceUnits() );
      if (M.getSubstanceUnits() == units);
      {
      }
      M.unsetSubstanceUnits();
      assertEquals( false, M.isSetSubstanceUnits() );
      if (M.getSubstanceUnits() != null);
      {
      }
    }

    public void test_L3_Model_timeUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetTimeUnits() );
      M.setTimeUnits(units);
      assertTrue(( units == M.getTimeUnits() ));
      assertEquals( true, M.isSetTimeUnits() );
      if (M.getTimeUnits() == units);
      {
      }
      M.unsetTimeUnits();
      assertEquals( false, M.isSetTimeUnits() );
      if (M.getTimeUnits() != null);
      {
      }
    }

    public void test_L3_Model_volumeUnits()
    {
      string units =  "mole";
      assertEquals( false, M.isSetVolumeUnits() );
      M.setVolumeUnits(units);
      assertTrue(( units == M.getVolumeUnits() ));
      assertEquals( true, M.isSetVolumeUnits() );
      if (M.getVolumeUnits() == units);
      {
      }
      M.unsetVolumeUnits();
      assertEquals( false, M.isSetVolumeUnits() );
      if (M.getVolumeUnits() != null);
      {
      }
    }

  }
}