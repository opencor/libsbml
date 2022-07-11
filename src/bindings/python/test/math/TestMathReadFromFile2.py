#
# @file    TestMathReadFromFile2.py
# @brief   Tests for reading MathML from files into ASTNodes.
#
# @author  Akiya Jouraku (Python conversion)
# @author  Sarah Keating 
# 
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/math/test/TestReadFromFile2.cpp
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


class TestMathReadFromFile2(unittest.TestCase):


  def test_read_MathML_2(self):
    reader = libsbml.SBMLReader()
    filename = "../../sbml/math/test/test-data/"
    filename += "mathML_2-invalid.xml"
    d = reader.readSBML(filename)
    if (d == None):
      pass    
    m = d.getModel()
    self.assertTrue( m != None )
    self.assertTrue( m.getNumFunctionDefinitions() == 2 )
    self.assertTrue( m.getNumInitialAssignments() == 1 )
    self.assertTrue( m.getNumRules() == 2 )
    fd = m.getFunctionDefinition(0)
    fd_math = fd.getMath()
    self.assertTrue( fd_math.getType() == libsbml.AST_LAMBDA )
    self.assertTrue( fd_math.getNumChildren() == 1 )
    self.assertTrue((  "lambda()" == libsbml.formulaToString(fd_math) ))
    child = fd_math.getChild(0)
    self.assertTrue( child.getType() == libsbml.AST_UNKNOWN )
    self.assertTrue( child.getNumChildren() == 0 )
    self.assertTrue((  "" == libsbml.formulaToString(child) ))
    fd = m.getFunctionDefinition(1)
    fd1_math = fd.getMath()
    self.assertTrue( fd1_math.getType() == libsbml.AST_LAMBDA )
    self.assertTrue( fd1_math.getNumChildren() == 2 )
    self.assertTrue((                            "lambda(x, piecewise(p, leq(x, 4)))" == libsbml.formulaToString(fd1_math) ))
    child1 = fd1_math.getRightChild()
    self.assertTrue( child1.getType() == libsbml.AST_FUNCTION_PIECEWISE )
    self.assertTrue( child1.getNumChildren() == 2 )
    self.assertTrue((                                      "piecewise(p, leq(x, 4))" == libsbml.formulaToString(child1) ))
    c1 = child1.getChild(0)
    self.assertTrue( c1.getType() == libsbml.AST_NAME )
    self.assertTrue( c1.getNumChildren() == 0 )
    self.assertTrue((  "p" == libsbml.formulaToString(c1) ))
    c2 = child1.getChild(1)
    self.assertTrue( c2.getType() == libsbml.AST_RELATIONAL_LEQ )
    self.assertTrue( c2.getNumChildren() == 2 )
    self.assertTrue((  "leq(x, 4)" == libsbml.formulaToString(c2) ))
    ia = m.getInitialAssignment(0)
    ia_math = ia.getMath()
    self.assertTrue( ia_math.getType() == libsbml.AST_FUNCTION_PIECEWISE )
    self.assertTrue( ia_math.getNumChildren() == 4 )
    self.assertTrue((                      "piecewise(-x, lt(x, 0), 0, eq(x, 0))" == libsbml.formulaToString(ia_math) ))
    child1 = ia_math.getChild(0)
    child2 = ia_math.getChild(1)
    child3 = ia_math.getChild(2)
    child4 = ia_math.getChild(3)
    self.assertTrue( child1.getType() == libsbml.AST_MINUS )
    self.assertTrue( child1.getNumChildren() == 1 )
    self.assertTrue((  "-x" == libsbml.formulaToString(child1) ))
    self.assertTrue( child2.getType() == libsbml.AST_RELATIONAL_LT )
    self.assertTrue( child2.getNumChildren() == 2 )
    self.assertTrue((  "lt(x, 0)" == libsbml.formulaToString(child2) ))
    self.assertTrue( child3.getType() == libsbml.AST_REAL )
    self.assertTrue( child3.getNumChildren() == 0 )
    self.assertTrue((  "0" == libsbml.formulaToString(child3) ))
    self.assertTrue( child4.getType() == libsbml.AST_RELATIONAL_EQ )
    self.assertTrue( child4.getNumChildren() == 2 )
    self.assertTrue((  "eq(x, 0)" == libsbml.formulaToString(child4) ))
    r = m.getRule(0)
    #r_math = r.getMath()
    #self.assertTrue( r_math == None )
    r = m.getRule(1)
    r1_math = r.getMath()
    self.assertTrue( r1_math.getType() == libsbml.AST_FUNCTION_LOG )
    self.assertTrue( r1_math.getNumChildren() == 2 )
    self.assertTrue((  "log(3, x)" == libsbml.formulaToString(r1_math) ))
    child1 = r1_math.getChild(0)
    child2 = r1_math.getChild(1)
    #self.assertTrue( child1.getType() == libsbml.AST_QUALIFIER_LOGBASE )
    #self.assertTrue( child1.getNumChildren() == 1 )
    #self.assertTrue( child2.getType() == libsbml.AST_NAME )
    #self.assertTrue( child2.getNumChildren() == 0 )
    #self.assertTrue((  "x" == libsbml.formulaToString(child2) ))
    #child2 = child1.getChild(0)
    #self.assertTrue( child2.getType() == libsbml.AST_REAL )
    #self.assertTrue( child2.getNumChildren() == 0 )
    #self.assertTrue((  "3" == libsbml.formulaToString(child2) ))
    d = None
    pass  

def suite():
  suite = unittest.TestSuite()
  suite.addTest(unittest.makeSuite(TestMathReadFromFile2))

  return suite

if __name__ == "__main__":
  if unittest.TextTestRunner(verbosity=1).run(suite()).wasSuccessful() :
    sys.exit(0)
  else:
    sys.exit(1)

