/** 
 *@cond doxygenLibsbmlInternal 
 **
 * @file    UnitFormulaFormatter.cpp
 * @brief   Formats an AST formula tree as a unit definition
 * @author  Sarah Keating
 * 
 * <!--------------------------------------------------------------------------
 * This file is part of libSBML.  Please visit http://sbml.org for more
 * information about SBML, and the latest version of libSBML.
 *
 * Copyright (C) 2020 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. University of Heidelberg, Heidelberg, Germany
 *     3. University College London, London, UK
 *
 * Copyright (C) 2019 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. University of Heidelberg, Heidelberg, Germany
 *
 * Copyright (C) 2013-2018 jointly by the following organizations:
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
 *     3. University of Heidelberg, Heidelberg, Germany
 *
 * Copyright (C) 2009-2013 jointly by the following organizations: 
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
 *  
 * Copyright (C) 2006-2008 by the California Institute of Technology,
 *     Pasadena, CA, USA 
 *  
 * Copyright (C) 2002-2005 jointly by the following organizations: 
 *     1. California Institute of Technology, Pasadena, CA, USA
 *     2. Japan Science and Technology Agency, Japan
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation.  A copy of the license agreement is provided
 * in the file named "LICENSE.txt" included with this software distribution and
 * also available online as http://sbml.org/software/libsbml/license.html
 * ---------------------------------------------------------------------- -->*/

#include <sbml/units/UnitFormulaFormatter.h>
#include <sbml/SBMLTransforms.h>
#include <sbml/SBMLDocument.h>
#include <sbml/util/util.h>
#include <sbml/util/IdList.h>



LIBSBML_CPP_NAMESPACE_BEGIN
#ifdef __cplusplus
/*
 *  constructs a UnitFormulaFormatter
 */
UnitFormulaFormatter::UnitFormulaFormatter(const Model *m)
 : model(m)
{
  mContainsUndeclaredUnits = false;
  mContainsInconsistentUnits = false;
  mCanIgnoreUndeclaredUnits = 2;
  depthRecursiveCall = 0;
}

/*
 *  destructor
 */
UnitFormulaFormatter::~UnitFormulaFormatter()
{
}

/*
  * visits the ASTNode and returns the unitDefinition of the formula
  * this function is really a dispatcher to the other
  * UnitFormulaFormatter::getUnitdefinition functions
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinition(const ASTNode * node, 
                                        bool inKL, int reactNo)
{  
  /** 
    * returns a copy of existing UnitDefinition* object (if any) that 
    * corresponds to a given ASTNode*. 
    * (This is for avoiding redundant recursive calls.)
    */

  std::map<const ASTNode*, UnitDefinition*>::iterator it = 
                                                unitDefinitionMap.find(node);
  if(it != unitDefinitionMap.end()) {
    return static_cast<UnitDefinition*>(it->second->clone());
  }

    
  UnitDefinition * ud = NULL;

  if (node == NULL)
  {
    return ud;
  }

  ++depthRecursiveCall;


  ASTNodeType_t type = node->getType();

  switch (type) 
  {
  /* functions that return a dimensionless result */
    case AST_FUNCTION_FACTORIAL:

    /* inverse hyerbolic functions */
    case AST_FUNCTION_ARCCOSH:
    case AST_FUNCTION_ARCCOTH:
    case AST_FUNCTION_ARCCSCH:
    case AST_FUNCTION_ARCSECH:
    case AST_FUNCTION_ARCSINH:
    case AST_FUNCTION_ARCTANH:

    /* inverse trig functions */
    case AST_FUNCTION_ARCCOS:
    case AST_FUNCTION_ARCCOT:
    case AST_FUNCTION_ARCCSC:
    case AST_FUNCTION_ARCSEC:
    case AST_FUNCTION_ARCSIN:
    case AST_FUNCTION_ARCTAN: 

    /* hyperbolic functions */
    case AST_FUNCTION_COSH:
    case AST_FUNCTION_COTH:
    case AST_FUNCTION_CSCH:
    case AST_FUNCTION_SECH:
    case AST_FUNCTION_SINH:
    case AST_FUNCTION_TANH: 

    /* trigonometry functions */
    case AST_FUNCTION_COS:
    case AST_FUNCTION_COT:
    case AST_FUNCTION_CSC:
    case AST_FUNCTION_SEC:
    case AST_FUNCTION_SIN:
    case AST_FUNCTION_TAN: 

    /* logarithmic functions */
    case AST_FUNCTION_EXP:
    case AST_FUNCTION_LN:
    case AST_FUNCTION_LOG:

    /* boolean */
    case AST_LOGICAL_AND:
    case AST_LOGICAL_NOT:
    case AST_LOGICAL_OR:
    case AST_LOGICAL_XOR:
    case AST_CONSTANT_FALSE:
    case AST_CONSTANT_TRUE:

    /* relational */
    case AST_RELATIONAL_EQ:
    case AST_RELATIONAL_GEQ:
    case AST_RELATIONAL_GT:
    case AST_RELATIONAL_LEQ:
    case AST_RELATIONAL_LT:
    case AST_RELATIONAL_NEQ:

      ud = getUnitDefinitionFromDimensionlessReturnFunction
                                                        (node, inKL, reactNo);
      break;

  /* functions that return same units */
    case AST_PLUS:
    case AST_MINUS:
    case AST_FUNCTION_ABS:
    case AST_FUNCTION_CEILING:
    case AST_FUNCTION_FLOOR:
  
      ud = getUnitDefinitionFromArgUnitsReturnFunction(node, inKL, reactNo);
      break;

  /* power functions */
    case AST_POWER:
    case AST_FUNCTION_POWER:
  
      ud = getUnitDefinitionFromPower(node, inKL, reactNo);
      break;

  /* times functions */
    case AST_TIMES:
  
      ud = getUnitDefinitionFromTimes(node, inKL, reactNo);
      break;

  /* divide functions */
    case AST_DIVIDE:
  
      ud = getUnitDefinitionFromDivide(node, inKL, reactNo);
      break;

  /* piecewise functions */
    case AST_FUNCTION_PIECEWISE:
  
      ud = getUnitDefinitionFromPiecewise(node, inKL, reactNo);
      break;

  /* root functions */
    case AST_FUNCTION_ROOT:
  
      ud = getUnitDefinitionFromRoot(node, inKL, reactNo);
      break;

  /* functions */
    case AST_LAMBDA:
    case AST_FUNCTION:
  
      ud = getUnitDefinitionFromFunction(node, inKL, reactNo);
      break;
    
  /* delay */
    case AST_FUNCTION_DELAY:
  
      ud = getUnitDefinitionFromDelay(node, inKL, reactNo);
      break;

    //  /* new types */
    //case AST_QUALIFIER_DEGREE:
    //case AST_QUALIFIER_LOGBASE:

    //  ud = getUnitDefinition(node->getChild(0), inKL, reactNo);
    //  break;

  /* others */

    /* numbers */
    case AST_INTEGER:
    case AST_REAL:
    case AST_REAL_E:
    case AST_RATIONAL:

    /* time */
    case AST_NAME_TIME:

    /* constants */
    case AST_CONSTANT_E:
    case AST_CONSTANT_PI:

    /* name of another component in the model */
    case AST_NAME:

      ud = getUnitDefinitionFromOther(node, inKL, reactNo);
      break;

    case AST_UNKNOWN:
    default:
      bool found = false;
      if (node->getNumPlugins() == 0)
      {
        ((ASTNode*)(node))->loadASTPlugins(NULL);
      }
      for (unsigned int p = 0; p < node->getNumPlugins(); p++)
      {
        const ASTBasePlugin* baseplugin = node->getPlugin(p);
        if (baseplugin->defines(node->getType()))
        {
          found = true;
          ud = baseplugin->getUnitDefinitionFromPackage(this, node, inKL, reactNo);
        }
      }
      if (!found)
      {
        if (node->isQualifier() == true)
        {
          /* code so that old and new ast classes will do the right thing */
          ud = getUnitDefinition(node->getChild(0), inKL, reactNo);
        }
        else
        {
          try
          {
            ud = new UnitDefinition(model->getSBMLNamespaces());
          }
          catch (...)
          {
            ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
              SBMLDocument::getDefaultVersion());
          }
        }
      }
      break;
  }
  // as a safety catch 
  if (ud == NULL)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }

  // dont simplify an empty ud
  if (ud->getNumUnits() > 1)
    UnitDefinition::simplify(ud);

  --depthRecursiveCall;

  if ( depthRecursiveCall != 0 )
  {
    if (unitDefinitionMap.end() == unitDefinitionMap.find(node))
    {
      /* adds a pair of ASTNode* (node) and 
         UnitDefinition* (ud) to the UnitDefinitionMap */
      unitDefinitionMap.insert(std::pair<const ASTNode*, 
        UnitDefinition*>(node,static_cast<UnitDefinition*>(ud->clone())));
      undeclaredUnitsMap.insert(std::pair<const ASTNode*, 
                                    bool>(node,mContainsUndeclaredUnits));
      inconsistentUnitsMap.insert(std::pair<const ASTNode*, bool>
        (node, mContainsInconsistentUnits));
      canIgnoreUndeclaredUnitsMap.insert(std::pair<const ASTNode*, 
                           unsigned int>(node,mCanIgnoreUndeclaredUnits));
    }
  }
  else
  {
    /** 
      * Clears two map objects because all recursive call has finished.
      */ 
    std::map<const ASTNode*, UnitDefinition*>::iterator it1 =
                                                unitDefinitionMap.begin();
    while( it1 != unitDefinitionMap.end() )
    {
      delete it1->second;
      ++it1;
    }
    unitDefinitionMap.clear();
    undeclaredUnitsMap.clear();
    inconsistentUnitsMap.clear();
    canIgnoreUndeclaredUnitsMap.clear();
  }

  /* if something is returned with an empty unitDefinition
   * it means not all units could be determined
   * 
   * NO !! it might mean the answer could not be determined
   * i.e. mole + second does not contain undeclared units
   * but the answer is indeterminate
   * 
   * so only mark as undeclared if we have not marked inconsistency
   */
  if (!mContainsInconsistentUnits && ud->getNumUnits() == 0)
  {
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
  }

  return ud;
}


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from a function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromFunction(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  unsigned int i, nodeCount;
  Unit * unit;
  ASTNode * fdMath;
  // ASTNode *newMath;
  //bool needDelete = false;
  unsigned int noBvars;

  if(node->getType() == AST_FUNCTION)
  {
    const FunctionDefinition *fd = 
                               model->getFunctionDefinition(node->getName());
    if (fd && fd->isSetMath())
    {
      noBvars = fd->getNumArguments();
      if (noBvars == 0)
      {
        fdMath = fd->getMath()->getLeftChild()->deepCopy();
      }
      else
      {
        fdMath = fd->getMath()->getRightChild()->deepCopy();
      }

	  nodeCount = 0;
      for (i = 0; i < noBvars; i++)
      {
        if (nodeCount < node->getNumChildren())
          fdMath->replaceArgument(fd->getArgument(i)->getName(), 
                                            node->getChild(nodeCount));
		nodeCount++;
      }
      ud = getUnitDefinition(fdMath, inKL, reactNo);
      delete fdMath;
    }
    else
    {
      try
      {
        ud = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
    }
  }
  else
  {
    /**
     * function is a lambda function - which wont have any units
     */
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    unit = ud->createUnit();
    unit->setKind(UNIT_KIND_DIMENSIONLESS);
    unit->initDefaults();
  }
  
  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from a times function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromTimes(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  UnitDefinition * tempUD;
  unsigned int numChildren = node->getNumChildren();
  unsigned int n = 0;
  unsigned int i;
  unsigned int currentIgnore = mCanIgnoreUndeclaredUnits;

  if (numChildren == 0)
  {
    /* times with no arguments is the identity which is 1 dimensionless */
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    Unit * u = ud->createUnit();
    u->initDefaults();
    u->setKind(UNIT_KIND_DIMENSIONLESS);
  }
  else
  {
    ud = getUnitDefinition(node->getChild(n), inKL, reactNo);
    if (mCanIgnoreUndeclaredUnits == 0) currentIgnore = 0;

    if (ud)
    {
      for(n = 1; n < numChildren; n++)
      {
        tempUD = getUnitDefinition(node->getChild(n), inKL, reactNo);
        if (mCanIgnoreUndeclaredUnits == 0) currentIgnore = 0;
        for (i = 0; i < tempUD->getNumUnits(); i++)
        {
          ud->addUnit(tempUD->getUnit(i));
        }
        delete tempUD;
      }
    }
    else
    {
      try
      {
        ud = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
    }
  }

  mCanIgnoreUndeclaredUnits = currentIgnore;
  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from a divide function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromDivide(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  UnitDefinition * tempUD;
  unsigned int i;
  Unit * unit;

  ud = getUnitDefinition(node->getLeftChild(), inKL, reactNo);

  if (node->getNumChildren() == 1)
    return ud;
  tempUD = getUnitDefinition(node->getRightChild(), inKL, reactNo);
  for (i = 0; i < tempUD->getNumUnits(); i++)
  {
    unit = tempUD->getUnit(i);
    /* dont change the exponent on a dimensionless unit */
    /* actually do as there may be a multiplier */
  //  if (unit->getKind() != UNIT_KIND_DIMENSIONLESS)
    unit->setExponentUnitChecking(-1 * unit->getExponentUnitChecking());
    ud->addUnit(unit);
  }
  delete tempUD;

  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from a power function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromPower(const ASTNode * node,
                                                 bool inKL, int reactNo)
{ 
  unsigned int numChildren = node->getNumChildren();

  if (numChildren == 0 || numChildren > 2)
  {
    UnitDefinition* ud;
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    return ud;
  }

  UnitDefinition * variableUD = getUnitDefinition(
                                       node->getLeftChild(), inKL, reactNo);

  if (numChildren == 1)
  {
    mContainsUndeclaredUnits = true;
    return variableUD;
  }

  // save the undeclared status of variable
  bool varHasUndeclared = mContainsUndeclaredUnits;
  unsigned int varCanIgnoreUndeclared = mCanIgnoreUndeclaredUnits;

  double exponentValue = 0.0;
  ASTNode * exponentNode = node->getRightChild();

  // is the exponent dimensionless or a number because if not it is a problem
  bool inconsistent = false;
  UnitDefinition* exponentUD = getUnitDefinition(exponentNode, inKL, reactNo);
  UnitDefinition::simplify(exponentUD);

  if (exponentNode->isInteger() == true ||
    exponentNode->isReal() == true ||
    exponentUD->isVariantOfDimensionless())
  {
    SBMLTransforms::IdValueMap values;
    SBMLTransforms::getComponentValuesForModel(model, values);
    exponentValue = SBMLTransforms::evaluateASTNode(node->getRightChild(), values, model);

    for (unsigned int n = 0; n < variableUD->getNumUnits(); n++)
    {
      Unit * unit = variableUD->getUnit(n);
      unit->setExponentUnitChecking(exponentValue * unit->getExponentAsDouble());
    }

    // restore undeclared status as it should come from variable
    mContainsUndeclaredUnits = varHasUndeclared;
    mCanIgnoreUndeclaredUnits = varCanIgnoreUndeclared;
  }
  else if (exponentUD != NULL && exponentUD->getNumUnits() > 0)
  {
    inconsistent = true;
  }
  else
  {
    mContainsUndeclaredUnits = true;
  }
  
  delete exponentUD;
  if (inconsistent)
  {
    for (unsigned int n = variableUD->getNumUnits(); n > 0; --n)
    {
      Unit * unit = variableUD->removeUnit(n-1);
      delete unit;
    }
    mContainsInconsistentUnits = true;
  }

  return variableUD;

}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from 
  * a piecewise function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromPiecewise(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  unsigned int n = 0;
  UnitDefinition *tempUD1 = NULL;
  /* this is fine if all other return branches have units
   * but if there are undeclared units these get ignored
   */
  ud = getUnitDefinition(node->getLeftChild(), inKL, reactNo);
  
 /* piecewise(a0, a1, a2, a3, ...)
   * a0 and a2, a(n_even) must have same units
   * a1, a3, a(n_odd) must be dimensionless
   */
  while (!mContainsUndeclaredUnits && n < node->getNumChildren())
  {
    n+=2;
    tempUD1 = getUnitDefinition(node->getChild(n), inKL, reactNo);
  
    if (tempUD1) delete tempUD1;
  }


  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from a root function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromRoot(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
/* this only works is the exponent is an integer - 
   * since a unit can only have an integral exponent 
   * but the mathml might do something like
   * pow(sqrt(m) * 2, 2) - which would be okay
   * unless we challenge the sqrt(m) !!
   */

  UnitDefinition * tempUD;
  UnitDefinition *tempUD2 = NULL;
  unsigned int i;
  Unit * unit;
  ASTNode * child, * child1;

  tempUD = getUnitDefinition(node->getRightChild(), inKL, reactNo);
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }

  if (node->getNumChildren() == 1)
    return ud;

  child1 = node->getLeftChild();
  
  if (child1->isQualifier() == true)
  {
    child = child1->getChild(0);
  }
  else
  {
    child = node->getLeftChild();
  }

  bool inconsistent = false;

  for (i = 0; i < tempUD->getNumUnits(); i++)
  {
    unit = tempUD->getUnit(i);
    // if unit is dimensionless it doesnt matter 
    if (unit->getKind() != UNIT_KIND_DIMENSIONLESS)
    {
      // if fractional exponents are created flag not to check units
      if (child->isInteger()) 
      {
        double doubleExponent = 
                 double(unit->getExponent())/double(child->getInteger());
        //if (floor(doubleExponent) != doubleExponent)
        //  mContainsUndeclaredUnits = true;
        unit->setExponentUnitChecking(doubleExponent);
      }
      else if (child->isReal())
      {
        double doubleExponent = 
                            double(unit->getExponent())/child->getReal();
        //if (floor(doubleExponent) != doubleExponent)
        //  mContainsUndeclaredUnits = true;
        unit->setExponentUnitChecking(doubleExponent);
      }
      else
      {

        tempUD2 = getUnitDefinition(child, inKL, reactNo);
        if (tempUD2 && tempUD2->getNumUnits() > 0)
        {
          UnitDefinition::simplify(tempUD2);

          if (tempUD2->isVariantOfDimensionless())
          {
            SBMLTransforms::IdValueMap values;
            SBMLTransforms::getComponentValuesForModel(model, values);
            double value = SBMLTransforms::evaluateASTNode(child, values);
            if (!util_isNaN(value))
            {
              double doubleExponent =
                double(unit->getExponent()) / value;
              //if (floor(doubleExponent) != doubleExponent)
              unit->setExponentUnitChecking(doubleExponent);
              //              mContainsUndeclaredUnits = true;
              //            unit->setExponentUnitChecking((int)(unit->getExponent()/value));
            }
            else
            {
              inconsistent = true;
            }
          }
          else
          {
            /* here the child is an expression with units
            * flag the expression as not checked
            */
            inconsistent = true;
          }
        }
        else
        {
          mContainsUndeclaredUnits = true;
        }
      }
    }
    if (!inconsistent)
    {
      ud->addUnit(unit);
    }
    else
    {
      mContainsInconsistentUnits = true;
    }
  }

  delete tempUD;
  if (tempUD2 != NULL)
    delete tempUD2;

  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from 
  * a delay function
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromDelay(const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  
  ud = getUnitDefinition(node->getLeftChild(), inKL, reactNo);

  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from 
  * a function returning dimensionless value
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromDimensionlessReturnFunction(
                                const ASTNode *node, bool inKL, int reactNo )
{ 
  UnitDefinition * ud;
  Unit *unit;
    
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }
    
  unit = ud->createUnit();
  unit->setKind(UNIT_KIND_DIMENSIONLESS);
  unit->initDefaults();

  /* save any existing value of undeclaredUnits/canIgnoreUndeclaredUnits */
  unsigned int originalIgnore = mCanIgnoreUndeclaredUnits;
  bool originalUndeclaredValue = mContainsUndeclaredUnits;
  //unsigned int currentIgnore = mCanIgnoreUndeclaredUnits;
  //bool currentUndeclared = mContainsUndeclaredUnits;

  // check for undeclared units in child expressions
  UnitDefinition * tempUd;
  unsigned int noUndeclared = 0;
  for (unsigned int i = 0; i < node->getNumChildren(); i++)
  {
    tempUd = getUnitDefinition(node->getChild(i), inKL, reactNo);
    if (getContainsUndeclaredUnits() == true)
    {
      // if we have used logbase we dont want to 
      // record that the unit is not declared
      if (node->getType() == AST_FUNCTION_LOG && i == 0)
      {
        // do nothing
      }
      else
      {
        noUndeclared++;
      }
    }
    delete tempUd;
  }
  
  if (noUndeclared == 0)
  {
    mCanIgnoreUndeclaredUnits = originalIgnore;
    mContainsUndeclaredUnits = originalUndeclaredValue;
  }
  else if (noUndeclared == node->getNumChildren())
  {
    mCanIgnoreUndeclaredUnits = originalIgnore;
    mContainsUndeclaredUnits = true;
  }
  else
  {
    mCanIgnoreUndeclaredUnits = false;
    mContainsUndeclaredUnits = true;
  }

  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from 
  * a function returning value with same units as argument(s)
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromArgUnitsReturnFunction
                                       (const ASTNode * node, 
                                        bool inKL, int reactNo)
{ 
  UnitDefinition * ud;
  UnitDefinition * tempUd;
  unsigned int i = 0;
  unsigned int n = 0;
  bool conflictingUnits = false;
 
  /* save any existing value of undeclaredUnits/canIgnoreUndeclaredUnits */
  unsigned int originalIgnore = mCanIgnoreUndeclaredUnits;
  bool originalUndeclaredValue = mContainsUndeclaredUnits;
  unsigned int currentIgnore = mCanIgnoreUndeclaredUnits;
  bool currentUndeclared = mContainsUndeclaredUnits;

  /* get first arg that is not a parameter with undeclared units */
  ud = getUnitDefinition(node->getChild(i), inKL, reactNo);
  while (getContainsUndeclaredUnits() == true
    && i < node->getNumChildren()-1)
  {
    if (originalUndeclaredValue == true)
      currentIgnore = 0;
    else
      currentIgnore = 1;


    currentUndeclared = true;

    i++;
    delete ud;
    resetFlags();
    ud = getUnitDefinition(node->getChild(i), inKL, reactNo);
  }

  /* loop thru remain children to determine undeclaredUnit status */
  if (mContainsUndeclaredUnits && i == node->getNumChildren()-1)
  {
    /* all children are parameters with undeclared units */
    currentIgnore = 0;
  }
  else
  {
    for (n = i+1; n < node->getNumChildren(); n++)
    {
      resetFlags();
      tempUd = getUnitDefinition(node->getChild(n), inKL, reactNo);
      if (tempUd->getNumUnits() > 0)
      {
        if (!UnitDefinition::areEquivalent(ud, tempUd))
        {
          conflictingUnits = true;
        }
      }
      if (getContainsUndeclaredUnits())
      {
        currentUndeclared = true;
        currentIgnore = 1;
      }
      delete tempUd;
    }
  }

  /* restore original value of undeclaredUnits */
  if (node->getNumChildren() > 1)
  {
    mContainsUndeclaredUnits = currentUndeclared;
  }

  /* temporary HACK while I figure this out */
  if (originalIgnore == 2)
  {
    mCanIgnoreUndeclaredUnits = currentIgnore;
  }

  // we know we have something like mole + second
  // we dont want to report either mole or second as the 'correct' answer
  if (conflictingUnits)
  {
    mContainsInconsistentUnits = true;
    for (unsigned int j = ud->getNumUnits(); j > 0; --j)
    {
      Unit * unit = ud->removeUnit(j - 1);
      delete unit;
    }
    
  }
  


  return ud;
}
/* @endcond */


/* @cond doxygenLibsbmlInternal */
/** 
  * returns the unitDefinition for the ASTNode from anything else
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromOther(const ASTNode * node,
    bool inKL, int reactNo)
{ 
  UnitDefinition * ud = NULL;
  const UnitDefinition * tempUd;
  Unit * unit = NULL;

  unsigned int n, found;
  double exponent;

  const KineticLaw * kl;

  /** 
   * ASTNode represents a number, a constant, TIME, DELAY, or
   * the name of another element of the model
   */

  if (node->isNumber())
  {
    /* in L3 a number can have units */
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (node->isSetUnits())
    {
      std::string units = node->getUnits();
      if (UnitKind_isValidUnitKindString(units.c_str(), 
                          model->getLevel(), model->getVersion()))
      {
        unit = ud->createUnit();
        unit->setKind(UnitKind_forName(units.c_str()));
        unit->initDefaults();
        mContainsUndeclaredUnits = false;
        mCanIgnoreUndeclaredUnits = 0;
      }
      else
      {
        tempUd = model->getUnitDefinition(units);
        if (tempUd != NULL)
        {
          for (n = 0; n < tempUd->getNumUnits(); n++)
          {
            ud->addUnit(tempUd->getUnit(n));
          }
          mContainsUndeclaredUnits = false;
          mCanIgnoreUndeclaredUnits = 0;
        }

      }
    }
    else
    {
      mContainsUndeclaredUnits = true;
      mCanIgnoreUndeclaredUnits = 0;
    }
  }
  else if (node->getType() == AST_CONSTANT_E)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
  }
  else if (node->getType() == AST_CONSTANT_PI)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    unit = ud->createUnit();
    unit->setKind(UNIT_KIND_DIMENSIONLESS);
    unit->initDefaults();
  }
  else if (node->isName())
  {
    if (node->getType() == AST_NAME_TIME)
    {
      ud = getTimeUnitDefinition();

      //try
      //{
      //  ud = new UnitDefinition(model->getSBMLNamespaces());
      //}
      //catch ( ... )
      //{
      //  ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      //    SBMLDocument::getDefaultVersion());
      //}
      //if (tempUd == NULL) 
      //{
      //  unit = ud->createUnit();
      //  unit->setKind(UnitKind_forName("second"));
      //  unit->initDefaults();
      //}
      //else
      //{
      //  for (n = 0; n < tempUd->getNumUnits(); n++)
      //  {
      //    ud->addUnit(tempUd->getUnit(n));
      //  }
      //}
    }
    /* must be the name of a compartment, species or parameter */
    else
    {
      found = 0;
      //n = 0;
      if (inKL)
      {
        if (model->getReaction((unsigned int)reactNo)->isSetKineticLaw())
        {
          kl = model->getReaction((unsigned int)reactNo)->getKineticLaw();
          ud = getUnitDefinitionFromParameter(
                                           kl->getParameter(node->getName()));
          if (ud != NULL)
          {
            found = 1;
          }
        }
      }
      if (found == 0)// && n < model->getNumCompartments())
      {
        ud = getUnitDefinitionFromCompartment(
                                      model->getCompartment(node->getName()));
        if (ud != NULL)
        {
          found = 1;
        }
      }

      if (found == 0)//&& n < model->getNumSpecies())
      {
        ud = getUnitDefinitionFromSpecies(
                                          model->getSpecies(node->getName()));
        if (ud != NULL)
        {
          found = 1;
        }
      }

      if (found == 0 )//&& n < model->getNumParameters())
      {
        ud = getUnitDefinitionFromParameter(
                                       model->getParameter(node->getName()));
        if (ud != NULL)
        {
          found = 1;
        }
      }

      if (found == 0 && model->getLevel() > 2)
      {
        // check for sr
        if (model->getSpeciesReference(node->getName()))
        {
          try
          {
            ud = new UnitDefinition(model->getSBMLNamespaces());
          }
          catch ( ... )
          {
            ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
              SBMLDocument::getDefaultVersion());
          }
          Unit *u = ud->createUnit();
          u->setKind(UNIT_KIND_DIMENSIONLESS);
          u->initDefaults();
          found = 1;
        }

      }
      
      if (found == 0 )//&& n < model->getNumParameters())
      {
        if (model->getReaction(node->getName()))
        {
          try
          {
            ud = new UnitDefinition(model->getSBMLNamespaces());
          }
          catch ( ... )
          {
            ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
              SBMLDocument::getDefaultVersion());
          }
          // <ci> element refers to reaction
          // units should be substance per time
          // NOTE: whether the KL has correct units is
          // checked elsewhere
          // but in L3 there might not be units for extent
          // or time
          /* check for builtin unit substance redefined */
          if (model->getLevel() < 3)
          {
            tempUd = model->getUnitDefinition("substance");
            if (tempUd == NULL) 
            {
              unit = ud->createUnit();
              unit->setKind(UnitKind_forName("mole"));
              unit->initDefaults();
              unit = NULL;
            }
            else
            {
              for (n = 0; n < tempUd->getNumUnits(); n++)
              {
                ud->addUnit(tempUd->getUnit(n));
              }
            }
            /* check for redinition of time
             * and add per time to ud
             */
            tempUd = model->getUnitDefinition("time");

            if (tempUd == NULL) 
            {
              unit = ud->createUnit();
              unit->setKind(UnitKind_forName("second"));
              unit->initDefaults();
              unit->setExponentUnitChecking(-1);
              unit = NULL;
            }
            else
            {
              for (n = 0; n < tempUd->getNumUnits(); n++)
              {
                unit = (const_cast<Unit*>(tempUd->getUnit(n)))->clone();
                exponent = unit->getExponent();
                unit->setExponentUnitChecking(exponent * -1);
                ud->addUnit(unit);
                delete unit;
              }
            }
          }
          else
          {
            /* in L3 the units will be extent per time
             * or possibly not declared at all !
             */
            std::string extentUnits = model->getExtentUnits();
            if (UnitKind_isValidUnitKindString(extentUnits.c_str(), 
                                               model->getLevel(), 
                                               model->getVersion()))
            {
              Unit* u = ud->createUnit();
              u->setKind(UnitKind_forName(extentUnits.c_str()));
              u->initDefaults();
            }
            else if (model->getUnitDefinition(extentUnits) != NULL)
            {
              for (unsigned int n1 = 0;
                n1 < model->getUnitDefinition(extentUnits)->getNumUnits(); n1++)
              {
                // need to prevent level/version mismatches
                // ud will have default level and veersion
                const Unit* uFromModel = 
                          model->getUnitDefinition(extentUnits)->getUnit(n1);
                if (uFromModel  != NULL)
                {
                  Unit* u = ud->createUnit();
                  u->setKind(uFromModel->getKind());
                  u->setExponent(uFromModel->getExponent());
                  u->setScale(uFromModel->getScale());
                  u->setMultiplier(uFromModel->getMultiplier());
                }
              }
            }
            else
            {
              mContainsUndeclaredUnits = true;
              mCanIgnoreUndeclaredUnits = 0;
            }

            std::string timeUnits = model->getTimeUnits();
            if (UnitKind_isValidUnitKindString(timeUnits.c_str(), 
                                               model->getLevel(), 
                                               model->getVersion()))
            {
              Unit* u = ud->createUnit();
              u->setKind(UnitKind_forName(timeUnits.c_str()));
              u->initDefaults();
              u->setExponent(-1);
            }
            else if (model->getUnitDefinition(timeUnits) != NULL)
            {
              for (unsigned int n1 = 0; 
                n1 < model->getUnitDefinition(timeUnits)->getNumUnits(); n1++)
              {
                // need to prevent level/version mismatches
                // ud will have default level and veersion
                const Unit* uFromModel = 
                            model->getUnitDefinition(timeUnits)->getUnit(n1);
                if (uFromModel  != NULL)
                {
                  Unit* u = ud->createUnit();
                  u->setKind(uFromModel->getKind());
                  u->setExponent(uFromModel->getExponent() * -1);
                  u->setScale(uFromModel->getScale());
                  u->setMultiplier(uFromModel->getMultiplier());
                }
              }
            }
            else
            {
              mContainsUndeclaredUnits = true;
              mCanIgnoreUndeclaredUnits = 0;
            }
          }
        }
      }
      
    }
  }

  /* catch case where a user has used a name in a formula that 
   * has not been declared anywhere in the model
   * return a unit definition with no units
   */
  if (ud == NULL)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }
  return ud;
}
/* @endcond */


/** 
  * returns the unitDefinition for the units of the compartment
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromCompartment
                                             (const Compartment * compartment)
{
  if (compartment == NULL)
  {
    return NULL;
  }

  UnitDefinition * ud = NULL;
  const UnitDefinition * tempUD;
  Unit * unit = NULL;
  unsigned int n, p;

  const char * units = compartment->getUnits().c_str();
  /* in l3 the units might be derived from attributes on the model */
  if (!strcmp(units, "") && compartment->getLevel() > 2)
  {
    switch ((int)(compartment->getSpatialDimensions()))
    {
    case 1:
      if (model->isSetLengthUnits())
        units = model->getLengthUnits().c_str();
      break;
    case 2:
      if (model->isSetAreaUnits())
        units = model->getAreaUnits().c_str();
      break;
    case 3:
      if (model->isSetVolumeUnits())
        units = model->getVolumeUnits().c_str();
      break;
    default:
      break;
    }
  }

  /* no units declared implies they default to the value appropriate
   * to the spatialDimensions of the compartment 
   * noting that it is possible that these have been overridden
   * using builtin units 
   *
   * BUT NO DEFAULTS IN L3
   */
  if (!strcmp(units, ""))
  {
    if (model->getLevel() < 3)
    {
      try
      {
        ud = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      switch ((int)(compartment->getSpatialDimensions()))
      {
        case 0:
          unit = ud->createUnit();
          unit->setKind(UNIT_KIND_DIMENSIONLESS);
          unit->initDefaults();
          break;
        case 1: 
          /* check for builtin unit length redefined */
          tempUD = model->getUnitDefinition("length");
          if (tempUD == NULL) 
          {
            unit = ud->createUnit();
            unit->setKind(UnitKind_forName("metre"));
            unit->initDefaults();
          }
          else
          {
            unit = ud->createUnit();
            unit->setKind(tempUD->getUnit(0)->getKind());
            unit->setMultiplier(tempUD->getUnit(0)->getMultiplier());
            unit->setScale(tempUD->getUnit(0)->getScale());
            unit->setExponentUnitChecking(tempUD->getUnit(0)->getExponentUnitChecking());
            unit->setOffset(tempUD->getUnit(0)->getOffset());
          }
          break;
        case 2:
          /* check for builtin unit area redefined */
          tempUD = model->getUnitDefinition("area");
          if (tempUD == NULL) 
          {
            unit = ud->createUnit();
            unit->setKind(UnitKind_forName("metre"));
            unit->initDefaults();
            unit->setExponentUnitChecking(2);
          }
          else
          {
            unit = ud->createUnit();
            unit->setKind(tempUD->getUnit(0)->getKind());
            unit->setMultiplier(tempUD->getUnit(0)->getMultiplier());
            unit->setScale(tempUD->getUnit(0)->getScale());
            unit->setExponentUnitChecking(tempUD->getUnit(0)->getExponentUnitChecking());
            unit->setOffset(tempUD->getUnit(0)->getOffset());
          }
          break;
        case 3:
          /* check for builtin unit volume redefined */
          tempUD = model->getUnitDefinition("volume");
          if (tempUD == NULL) 
          {
            unit = ud->createUnit();
            unit->setKind(UnitKind_forName("litre"));
            unit->initDefaults();
          }
          else
          {
            unit = ud->createUnit();
            unit->setKind(tempUD->getUnit(0)->getKind());
            unit->setMultiplier(tempUD->getUnit(0)->getMultiplier());
            unit->setScale(tempUD->getUnit(0)->getScale());
            unit->setExponentUnitChecking(tempUD->getUnit(0)->getExponentUnitChecking());
            unit->setOffset(tempUD->getUnit(0)->getOffset());
          }
          break;
        default:
          break;
      }
    }
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (UnitKind_isValidUnitKindString(units, 
                          compartment->getLevel(), compartment->getVersion()))
    {
      unit = ud->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (!strcmp(units, model->getUnitDefinition(n)->getId().c_str()))
        {
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = ud->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
          }
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (Unit_isBuiltIn(units, model->getLevel()) && ud->getNumUnits()==0)
    {
      if (!strcmp(units, "volume"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_LITRE);
        unit->initDefaults();
      }
      else if (!strcmp(units, "area"))
      {
        unit = ud->createUnit();
        unit->setKind(UnitKind_forName("metre"));
        unit->initDefaults();
        unit->setExponentUnitChecking(2);
      }
      else if (!strcmp(units, "length"))
      {
        unit = ud->createUnit();
        unit->setKind(UnitKind_forName("metre"));
        unit->initDefaults();
      }
    }
  }

  // as a safety catch 
  if (ud == NULL)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }

  return ud;
}

/** 
  * returns the unitDefinition for the units of the species
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromSpecies(const Species * species)
{
  if (species == NULL)
  {
    return NULL;
  }
  
  UnitDefinition * ud = NULL;
  const UnitDefinition * tempUd;
  UnitDefinition *subsUD = NULL;
  UnitDefinition *sizeUD = NULL;
  Unit * unit = NULL;
  const Compartment * c;
  unsigned int n, p;

  const char * units        = species->getSubstanceUnits().c_str();
  const char * spatialUnits = species->getSpatialSizeUnits().c_str();


  /* in l3 the units might be derived from attributes on the model */
  if (!strcmp(units, "") && species->getLevel() > 2)
  {
    if (model->isSetSubstanceUnits())
      units = model->getSubstanceUnits().c_str();
  }
  /* deal with substance units */
 
  /* no units declared implies they default to the value substance
   * BUT NO DEFAULTS IN L3
   */
  if (!strcmp(units, ""))
  {
    try
    {
      subsUD = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (species->getLevel() < 3)
    {
      /* check for builtin unit substance redefined */
      tempUd = model->getUnitDefinition("substance");
      if (tempUd == NULL) 
      {
        unit = subsUD->createUnit();
        unit->setKind(UnitKind_forName("mole"));
        unit->initDefaults();
      }
      else
      {
        unit = subsUD->createUnit();
        unit->setKind(tempUd->getUnit(0)->getKind());
        unit->setMultiplier(tempUd->getUnit(0)->getMultiplier());
        unit->setScale(tempUd->getUnit(0)->getScale());
        unit->setExponentUnitChecking(tempUd->getUnit(0)->getExponentUnitChecking());
        unit->setOffset(tempUd->getUnit(0)->getOffset());
      }
      unit = NULL;
    }
    else
    {
      // units is undefined 

      // as a safety catch
      return subsUD;
    }
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */
    if (UnitKind_isValidUnitKindString(units, 
                                 species->getLevel(), species->getVersion()))
    {
      try
      {
        subsUD = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      unit = subsUD->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
      unit = NULL;
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (units == model->getUnitDefinition(n)->getId())
        {
          try
          {
            subsUD = new UnitDefinition(model->getSBMLNamespaces());
          }
          catch ( ... )
          {
            subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
              SBMLDocument::getDefaultVersion());
          }
          
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = subsUD->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
            unit = NULL;
          }
          break;
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (Unit_isBuiltIn(units, model->getLevel()) && subsUD == NULL)
    {
      try
      {
        subsUD = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }

      if (!strcmp(units, "substance"))
      {
        unit = subsUD->createUnit();
        unit->setKind(UNIT_KIND_MOLE);
        unit->initDefaults();
        unit = NULL;
      }
    }
    else if (subsUD == NULL)
    {
      // units is undefined 

      // as a safety catch
      try
      {
        subsUD = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      return subsUD;
    }

  }
  if (species->getHasOnlySubstanceUnits())
  {
    ud = subsUD;
    return ud;
  }

  /* get the compartment containing the species */
  c = model->getCompartment(species->getCompartment().c_str());

  if (c && ((c->getLevel() < 3 && c->getSpatialDimensions() == 0)
    || (c->getLevel() > 2 && c->isSetSpatialDimensions() && 
    c->getSpatialDimensions() == 0)))
  {
    ud = subsUD;
    return ud;
  }

  /* deal with spatial size units */

  /* no units declared implies they default to the value of compartment size */
  if (!strcmp(spatialUnits, ""))
  {
    sizeUD   = getUnitDefinitionFromCompartment(c);
    if (species->getLevel() > 2 && sizeUD && sizeUD->getNumUnits() == 0)
    {
      /* compartment units are not defined */
      delete sizeUD;
      if (subsUD != NULL) delete subsUD;
      try
      {
        subsUD = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      return subsUD;
    }
  }
  else
  {
    try
    {
      sizeUD = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      sizeUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (UnitKind_isValidUnitKindString(spatialUnits, species->getLevel(), 
                                                     species->getVersion()))
    {
      unit = sizeUD->createUnit();
      unit->setKind(UnitKind_forName(spatialUnits));
      unit->initDefaults();
      unit = NULL;
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (spatialUnits == model->getUnitDefinition(n)->getId())
        {
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = sizeUD->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                    model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                         model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                      model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                        model->getUnitDefinition(n)->getUnit(p)->getOffset());
            unit = NULL;
          }
          break;
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (Unit_isBuiltIn(spatialUnits, model->getLevel()) && sizeUD->getNumUnits()==0)
    {
      if (!strcmp(spatialUnits, "volume"))
      {
        unit = sizeUD->createUnit();
        unit->setKind(UNIT_KIND_LITRE);
        unit->initDefaults();
      }
      else if (!strcmp(spatialUnits, "area"))
      {
        unit = sizeUD->createUnit();
        unit->setKind(UNIT_KIND_METRE);
        unit->initDefaults();
        unit->setExponentUnitChecking(2);
      }
      else if (!strcmp(spatialUnits, "length"))
      {
        unit = sizeUD->createUnit();
        unit->setKind(UNIT_KIND_METRE);
        unit->initDefaults();
      }
    }
  }

  /* units of the species are units substance/size */
  ud = subsUD;

  /* shouldnt really happen but if someone is creating invalid
   * sbml the sizeUD may be NULL
   */
  if (sizeUD != NULL)
  {
    for (n = 0; n < sizeUD->getNumUnits(); n++)
    {
      unit = sizeUD->getUnit(n);
      unit->setExponentUnitChecking(-1 * unit->getExponentUnitChecking());

      ud->addUnit(unit);
    }
  }
  // as a safety catch 
  if (ud == NULL)
  {
    try
    {
      subsUD = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      subsUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }

  delete sizeUD;

  return ud;
}

/** 
  * returns the unitDefinition for the units of the parameter
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromParameter
                                                (const Parameter * parameter)
{
  if (parameter == NULL)
  {
    return NULL;
  }

  UnitDefinition * ud = NULL;
  Unit * unit = NULL;
  unsigned int n, p;

  const char * units = parameter->getUnits().c_str();

 /* no units declared */
  if (!strcmp(units, ""))
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */

    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (UnitKind_isValidUnitKindString(units, 
                              parameter->getLevel(), parameter->getVersion()))
    {
      unit = ud->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (!strcmp(units, model->getUnitDefinition(n)->getId().c_str()))
        {
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = ud->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentAsDouble());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
          }
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (Unit_isBuiltIn(units, model->getLevel()) && ud->getNumUnits()==0)
    {

      if (!strcmp(units, "substance"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_MOLE);
        unit->initDefaults();
      }
      else if (!strcmp(units, "volume"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_LITRE);
        unit->initDefaults();
      }
      else if (!strcmp(units, "area"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_METRE);
        unit->initDefaults();
        unit->setExponentUnitChecking(2);
      }
      else if (!strcmp(units, "length"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_METRE);
        unit->initDefaults();
      }
      else if (!strcmp(units, "time"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_SECOND);
        unit->initDefaults();
      }
    }

  }
  // as a safety catch 
  if (ud == NULL)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }

  return ud;
}

/** 
  * returns the unitDefinition for the time units of the event
  */
UnitDefinition * 
UnitFormulaFormatter::getUnitDefinitionFromEventTime(const Event * event)
{
  if (event == NULL)
  {
    return NULL;
  }
  UnitDefinition * ud = NULL;
  UnitDefinition * tempUd = NULL;
  Unit * unit;
  unsigned int n, p;

  const char * units = event->getTimeUnits().c_str();
  if (event->getLevel() > 2)
    units = model->getTimeUnits().c_str();

 /* no units declared */
  if (!strcmp(units, ""))
  {
    /* defaults to time in L2
    * check for redefinition of time
    */
    if (event->getLevel() < 3)
    {
      tempUd = (UnitDefinition*)(model->getUnitDefinition("time"));

      try
      {
        ud = new UnitDefinition(model->getSBMLNamespaces());
      }
      catch ( ... )
      {
        ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      if (tempUd == NULL) 
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_SECOND);
        unit->initDefaults();
      }
      else
      {
        for (n = 0; n < tempUd->getNumUnits(); n++)
        {
          ud->addUnit(tempUd->getUnit(n));
        }
      }
    }
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */

    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
    if (UnitKind_isValidUnitKindString(units, 
                                     event->getLevel(), event->getVersion()))
    {
      unit = ud->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (!strcmp(units, model->getUnitDefinition(n)->getId().c_str()))
        {
          
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = ud->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
          }
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (event->getLevel() < 3)
    {
      if (Unit_isBuiltIn(units, model->getLevel()) && ud->getNumUnits()==0)
      {
        if (!strcmp(units, "time"))
        {
          unit = ud->createUnit();
          unit->setKind(UNIT_KIND_SECOND);
          unit->initDefaults();
        }
      }

    }
  }
  // as a safety catch 
  if (ud == NULL)
  {
    try
    {
      ud = new UnitDefinition(model->getSBMLNamespaces());
    }
    catch ( ... )
    {
      ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
        SBMLDocument::getDefaultVersion());
    }
  }

  return ud;
}

/**
 * Returns the unitDefinition constructed
 * from the extent units of this Model.
 */
UnitDefinition * 
UnitFormulaFormatter::getExtentUnitDefinition()
{
  UnitDefinition * ud;
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }
  Unit * unit = NULL;
  unsigned int n, p;

  const char * units = model->getExtentUnits().c_str();

 /* no units declared */
  if (!strcmp(units, ""))
  {
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */

    if (UnitKind_isValidUnitKindString(units, 
                              model->getLevel(), model->getVersion()))
    {
      unit = ud->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (!strcmp(units, model->getUnitDefinition(n)->getId().c_str()))
        {
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = ud->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
          }
        }
      }
    }
  }
  return ud;
}

UnitDefinition * 
UnitFormulaFormatter::getSpeciesSubstanceUnitDefinition(const Species * species)
{
  if (species == NULL)
  {
    return NULL;
  }
  
  UnitDefinition * ud;
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }
  const UnitDefinition * tempUd = NULL;
  Unit * unit = NULL;
  unsigned int n, p;

  const char * units        = species->getSubstanceUnits().c_str();


  /* in l3 the units might be derived from attributes on the model */
  if (!strcmp(units, "") && species->getLevel() > 2)
  {
    if (model->isSetSubstanceUnits())
      units = model->getSubstanceUnits().c_str();
  }
  /* deal with substance units */
 
  /* no units declared implies they default to the value substance
   * BUT NO DEFAULTS IN L3
   */
  if (!strcmp(units, ""))
  {
    if (species->getLevel() < 3)
    {
      /* check for builtin unit substance redefined */
      tempUd = model->getUnitDefinition("substance");
      if (tempUd == NULL) 
      {
        unit = ud->createUnit();
        unit->setKind(UnitKind_forName("mole"));
        unit->initDefaults();
      }
      else
      {
        unit = ud->createUnit();
        unit->setKind(tempUd->getUnit(0)->getKind());
        unit->setMultiplier(tempUd->getUnit(0)->getMultiplier());
        unit->setScale(tempUd->getUnit(0)->getScale());
        unit->setExponentUnitChecking(tempUd->getUnit(0)->getExponentUnitChecking());
        unit->setOffset(tempUd->getUnit(0)->getOffset());
      }
      unit = NULL;
    }
    else
    {
      mContainsUndeclaredUnits = true;
      mCanIgnoreUndeclaredUnits = 0;
    }
  }
  else
  {
    /* units can be a predefined unit kind
    * a unit definition id or a builtin unit
    */
    if (UnitKind_isValidUnitKindString(units, 
                                 species->getLevel(), species->getVersion()))
    {
      unit = ud->createUnit();
      unit->setKind(UnitKind_forName(units));
      unit->initDefaults();
      unit = NULL;
    }
    else 
    {
      for (n = 0; n < model->getNumUnitDefinitions(); n++)
      {
        if (!strcmp(units, model->getUnitDefinition(n)->getId().c_str()))
        {
          for (p = 0; p < model->getUnitDefinition(n)->getNumUnits(); p++)
          {
            unit = ud->createUnit();
            unit->setKind(model->getUnitDefinition(n)->getUnit(p)->getKind());
            unit->setMultiplier(
                   model->getUnitDefinition(n)->getUnit(p)->getMultiplier());
            unit->setScale(
                        model->getUnitDefinition(n)->getUnit(p)->getScale());
            unit->setExponentUnitChecking(
                     model->getUnitDefinition(n)->getUnit(p)->getExponentUnitChecking());
            unit->setOffset(
                       model->getUnitDefinition(n)->getUnit(p)->getOffset());
            unit = NULL;
          }
        }
      }
    }
    /* now check for builtin units 
     * this check is left until now as it is possible for a builtin 
     * unit to be reassigned using a unit definition and thus will have 
     * been picked up above
     */
    if (Unit_isBuiltIn(units, model->getLevel()) && ud->getNumUnits()==0)
    {
      if (!strcmp(units, "substance"))
      {
        unit = ud->createUnit();
        unit->setKind(UNIT_KIND_MOLE);
        unit->initDefaults();
        unit = NULL;
      }
    }
  }

  return ud;
}

UnitDefinition * 
UnitFormulaFormatter::getSpeciesExtentUnitDefinition(const Species * species)
{
  if (species == NULL)
  {
    return NULL;
  }
  unsigned int n;
  UnitDefinition * ud;
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }
  Unit * unit = NULL;

  /* get model extent - if there is none then species has none */
  UnitDefinition * modelExtent = getExtentUnitDefinition();
  if (modelExtent == NULL || modelExtent->getNumUnits() == 0)
  {
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
    delete modelExtent;
    return ud;
  }

  UnitDefinition *conversion = NULL;

  /* get conversionFactor - if none or if it has no units bail*/
  if (species->isSetConversionFactor())
  {
    conversion = getUnitDefinitionFromParameter(
      model->getParameter(species->getConversionFactor()));
  }
  else if (model->isSetConversionFactor())
  {
    conversion = getUnitDefinitionFromParameter(
      model->getParameter(model->getConversionFactor()));
  }
    
  if (conversion == NULL || conversion->getNumUnits() == 0)
  {
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
    delete modelExtent;
    delete conversion;
    return ud;
  }
  
  /* both exist so multiply */
  for (n = 0; n < modelExtent->getNumUnits(); n++)
  {
    unit = ud->createUnit();
    unit->setKind(modelExtent->getUnit(n)->getKind());
    unit->setMultiplier(
            modelExtent->getUnit(n)->getMultiplier());
    unit->setScale(
            modelExtent->getUnit(n)->getScale());
    unit->setExponentUnitChecking(
            modelExtent->getUnit(n)->getExponentUnitChecking());
    unit->setOffset(
            modelExtent->getUnit(n)->getOffset());
  }
  for (n = 0; n < conversion->getNumUnits(); n++)
  {
    unit = ud->createUnit();
    unit->setKind(conversion->getUnit(n)->getKind());
    unit->setMultiplier(
            conversion->getUnit(n)->getMultiplier());
    unit->setScale(
            conversion->getUnit(n)->getScale());
    unit->setExponentUnitChecking(
            conversion->getUnit(n)->getExponentUnitChecking());
    unit->setOffset(
            conversion->getUnit(n)->getOffset());
  }

  UnitDefinition::simplify(ud);

  delete modelExtent;
  delete conversion;
  return ud;
}

  /* @cond doxygenLibsbmlInternal */

UnitDefinition * 
UnitFormulaFormatter::getTimeUnitDefinition()
{
  UnitDefinition * ud = NULL;

  std::string timeUnits = model->getTimeUnits();
  if (model->getLevel() < 3)
  {
    if (model->getUnitDefinition("time") != NULL)
      timeUnits = "time";
    else
      timeUnits = "second";
  }

  char * charTime = safe_strdup(timeUnits.c_str());
  try
  {
    ud = new UnitDefinition(model->getSBMLNamespaces());
  }
  catch ( ... )
  {
    ud = new UnitDefinition(SBMLDocument::getDefaultLevel(),
      SBMLDocument::getDefaultVersion());
  }

  if (UnitKind_isValidUnitKindString(charTime,
                                      model->getLevel(), 
                                      model->getVersion()))
  {
    Unit* u = ud->createUnit();
    u->setKind(UnitKind_forName(charTime));
    u->initDefaults();
  }
  else if (model->getUnitDefinition(timeUnits) != NULL)
  {
    for (unsigned int n1 = 0; 
      n1 < model->getUnitDefinition(timeUnits)->getNumUnits(); n1++)
    {
      // need to prevent level/version mismatches
      // ud will have default level and veersion
      const Unit* uFromModel = 
                  model->getUnitDefinition(timeUnits)->getUnit(n1);
      if (uFromModel  != NULL)
      {
        Unit* u = ud->createUnit();
        u->setKind(uFromModel->getKind());
        u->setExponent(uFromModel->getExponent());
        u->setScale(uFromModel->getScale());
        u->setMultiplier(uFromModel->getMultiplier());
      }
    }
  }
  else
  {
    mContainsUndeclaredUnits = true;
    mCanIgnoreUndeclaredUnits = 0;
  }

  safe_free(charTime);
  return ud;

}

  /** @endcond */


/** 
  * returns canIgnoreUndeclaredUnits value
  */
bool 
UnitFormulaFormatter::canIgnoreUndeclaredUnits()
{
  if (mCanIgnoreUndeclaredUnits == 2
    || mCanIgnoreUndeclaredUnits == 0)
    return false;
  else
    return true;
}


/** 
  * returns undeclaredUnits value
  */
bool 
UnitFormulaFormatter::getContainsUndeclaredUnits()
{
  return mContainsUndeclaredUnits;
}

/**
* returns undeclaredUnits value
*/
bool
UnitFormulaFormatter::getContainsInconsistentUnits()
{
  return mContainsInconsistentUnits;
}

/**
  * resets the undeclaredUnits and canIgnoreUndeclaredUnits flags
  * since these will different for each math formula
  */
void 
UnitFormulaFormatter::resetFlags()
{
  mContainsInconsistentUnits = false;
  mContainsUndeclaredUnits = false;
  mCanIgnoreUndeclaredUnits = 2;
}

UnitDefinition *
UnitFormulaFormatter::inferUnitDefinition(UnitDefinition* expectedUD, 
    const ASTNode * LHS, std::string id, bool inKL, int reactNo)
{
  UnitDefinition * resultUD = NULL;
  if (expectedUD == NULL) return NULL;

  ASTNode * math = LHS->deepCopy();
  UnitDefinition * tempUD = expectedUD->clone();
  math->reduceToBinary();

  bool isolated = false;
  ASTNode * child1 = NULL, * child2 = NULL;
  unsigned int numChildren = math->getNumChildren();

  // is the math just the ci element
  if (numChildren == 0 && math->getType() == AST_NAME
    && math->getName() == id)
  {
    resultUD = new UnitDefinition(*tempUD);
    isolated = true;
  }

  while (isolated == false && numChildren > 0)
  {
    child1 = math->getChild(0)->deepCopy();
    if (numChildren != 2)
    {
      /* dont support this yet */
      //isolated = true;
      resultUD = NULL;
      break;
    }
    else
    {
      child2 = math->getChild(1)->deepCopy();
    }

    if (child1 != NULL && child1->containsVariable(id) == true)
    {
      if (child1->getType() == AST_NAME && child1->getName() == id)
      {
        resultUD = inverseFunctionOnUnits(tempUD, child2, math->getType(),
                                          inKL, reactNo);
        isolated = true;
        continue;
      }
      else
      {
        UnitDefinition * tempUD1 = inverseFunctionOnUnits(tempUD, child2, 
                                              math->getType(), inKL, reactNo);
        delete tempUD;
        tempUD = tempUD1->clone();
        delete tempUD1;
        delete math;
        math = child1->deepCopy();
        if (child1 != NULL) 
        {
           delete child1;
           child1 = NULL;
        }
        if (child2 != NULL)
        {
          delete child2;
          child2 = NULL;
        }
        numChildren = math->getNumChildren();
        continue;
      }
    }
    else if (child2 != NULL && child2->containsVariable(id) == true)
    {
      if (child2->getType() == AST_NAME && child2->getName() == id)
      {
        resultUD = inverseFunctionOnUnits(tempUD, child1, math->getType(),
                                          inKL, reactNo, true);
        isolated = true;
        continue;
      }
      else
      {
        UnitDefinition * tempUD1 = inverseFunctionOnUnits(tempUD, child1, 
                                              math->getType(), inKL, reactNo, true);
        delete tempUD;
        tempUD = tempUD1->clone();
        delete tempUD1;
        delete math;
        math = child2->deepCopy();
		if (child1 != NULL)
		{
			delete child1;
			child1 = NULL;
		}
		if (child2 != NULL)
		{
			delete child2;
			child2 = NULL;
		}
        numChildren = math->getNumChildren();
        continue;
      }
    }
    else
    {
      //isolated = true;
      resultUD = NULL;
      break;
    }
  }

  delete math;
  delete tempUD;
  if (child1 != NULL) 
    delete child1;
  if (child2 != NULL) 
    delete child2;

  return resultUD;
}

UnitDefinition *
UnitFormulaFormatter::inverseFunctionOnUnits(UnitDefinition* expectedUD,
    const ASTNode * math, ASTNodeType_t functionType, 
    bool inKL, int reactNo, bool unknownInLeftChild)
{
  UnitDefinition * resolvedUD = NULL;
  UnitDefinition * mathUD = this->getUnitDefinition(math, inKL, reactNo);

  switch (functionType)
  {
  case AST_TIMES:
    resolvedUD = UnitDefinition::divide(expectedUD, mathUD);
    break;
  case AST_DIVIDE:
    if (unknownInLeftChild == true)
    {
      resolvedUD = UnitDefinition::divide(mathUD, expectedUD);
    }
    else
    {
      resolvedUD = UnitDefinition::combine(expectedUD, mathUD);
    }
    break;
  case AST_PLUS:
  case AST_MINUS:
    resolvedUD = UnitDefinition::combine(expectedUD, NULL);
    break;
  case AST_POWER:
    if (unknownInLeftChild == true)
    {
      try
      {
        resolvedUD = new UnitDefinition(expectedUD->getSBMLNamespaces());
      }
      catch ( ... )
      {
        resolvedUD = new UnitDefinition(SBMLDocument::getDefaultLevel(),
          SBMLDocument::getDefaultVersion());
      }
      Unit * u = resolvedUD->createUnit();
      u->setKind(UNIT_KIND_DIMENSIONLESS);
      u->initDefaults();
    }
    else
    {
      if (mathUD == NULL || mathUD->getNumUnits() == 0 
        || mathUD->isVariantOfDimensionless() == true)
      {
        SBMLTransforms::IdValueMap values;
        SBMLTransforms::getComponentValuesForModel(this->model, values);
        double exp = 1.0/(SBMLTransforms::evaluateASTNode(math, values, this->model));
        resolvedUD = new UnitDefinition(*expectedUD);
        for (unsigned int i = 0; i < resolvedUD->getNumUnits(); i++)
        {
          Unit * u = resolvedUD->getUnit(i);
          if (u->getLevel() < 3)
          {
            u->setExponent((int)(u->getExponent() * exp));
          }
          else
          {
            u->setExponent(u->getExponentAsDouble() * exp);
          }
        }
      }
    }
    break;
  default:
    break;
  }

  if (mathUD != NULL) delete mathUD;

  return resolvedUD;
}

bool
UnitFormulaFormatter::variableCanBeDeterminedFromMath(const ASTNode * node, 
                                                  std::string id)
{
  bool possible = false;

  if (node != NULL)
  {
    if (node->containsVariable(id) == true)
    {
      if (node->getNumVariablesWithUndeclaredUnits() == 1)
      {
        possible = true;
      }
    }
  }

  return possible;
}


bool
UnitFormulaFormatter::possibleToUseUnitsData(FormulaUnitsData * fud)
{
  bool possible = false;

  if (fud != NULL)
  { 
    if (fud->getContainsUndeclaredUnits() == false)
    {
      possible = true;
    }
    else if (fud->getCanIgnoreUndeclaredUnits() == true)
    {
      possible = true;
    }
  }

  return possible;
}

#endif /* __cplusplus */
/** @cond doxygenIgnored */
/* NOT YET NECESSARY 
LIBSBML_EXTERN
UnitFormulaFormatter_t* 
UnitFormulaFormatter_create(Model_t * model)
{
  return new(nothrow) UnitFormulaFormatter(model);
}

LIBSBML_EXTERN
UnitDefinition_t * 
UnitFormulaFormatter_getUnitDefinition(UnitFormulaFormatter_t * uff,
                                       const ASTNode_t * node, 
                                       unsigned int inKL, int reactNo)
{
  return uff->getUnitDefinition(node, inKL, reactNo);
}

LIBSBML_EXTERN
UnitDefinition_t * 
UnitFormulaFormatter_getUnitDefinitionFromCompartment
                                         (UnitFormulaFormatter_t * uff,
                                          const Compartment_t * compartment)
{
  return uff->getUnitDefinitionFromCompartment(compartment);
}

LIBSBML_EXTERN
UnitDefinition_t * 
UnitFormulaFormatter_getUnitDefinitionFromSpecies
                                         (UnitFormulaFormatter_t * uff,
                                          const Species_t * species)
{
  return uff->getUnitDefinitionFromSpecies(species);
}

LIBSBML_EXTERN
UnitDefinition_t * 
UnitFormulaFormatter_getUnitDefinitionFromParameter
                                         (UnitFormulaFormatter_t * uff,
                                          const Parameter * parameter)
{
  return uff->getUnitDefinitionFromParameter(parameter);
}

LIBSBML_EXTERN
UnitDefinition_t * 
UnitFormulaFormatter_getUnitDefinitionFromEventTime
                                         (UnitFormulaFormatter_t * uff,
                                          const Event * event)
{
  return uff->getUnitDefinitionFromEventTime(event);
}

LIBSBML_EXTERN
int 
UnitFormulaFormatter_canIgnoreUndeclaredUnits(UnitFormulaFormatter_t * uff)
{
  return static_cast <int> (uff->canIgnoreUndeclaredUnits());
}

LIBSBML_EXTERN
int
UnitFormulaFormatter_getContainsUndeclaredUnits(UnitFormulaFormatter_t * uff)
{
  return static_cast <int> (uff->getContainsUndeclaredUnits());
}

LIBSBML_EXTERN
void 
UnitFormulaFormatter_resetFlags(UnitFormulaFormatter_t * uff)
{
  uff->resetFlags();
}



*/
/** @endcond */

LIBSBML_CPP_NAMESPACE_END
