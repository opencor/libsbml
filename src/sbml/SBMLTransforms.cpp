/**
 * @file    SBMLTransforms.cpp
 * @brief   Transform functions
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
 * in the file named "LICENSE.txt" included with this software distribution
 * and also available online as http://sbml.org/software/libsbml/license.html
 * ---------------------------------------------------------------------- -->*/

#include <sbml/SBMLTransforms.h>
#include <sbml/util/util.h>
#include <sbml/Model.h>

#include <cstring>
#include <math.h>

#include <sbml/util/IdList.h>

/** @cond doxygenIgnored */
using namespace std;
/** @endcond */

LIBSBML_CPP_NAMESPACE_BEGIN
#ifdef __cplusplus

/** @cond doxygenLibsbmlInternal */
SBMLTransforms::ModelValuesMap SBMLTransforms::mModelValues;

void
SBMLTransforms::replaceFD(ASTNode * node, const ListOfFunctionDefinitions *lofd, const IdList* idsToExclude /*= NULL*/)
{
  if (lofd == NULL) 
    return;

  bool replaced = false;

  /* write a list of fd ids */
  IdList ids;
  unsigned int i;
  unsigned int skipped = 0;
  for (i = 0; i < lofd->size(); i++)
  {
    const std::string& id = lofd->get(i)->getId();
    if (idsToExclude == NULL || !idsToExclude->contains(id))
    ids.append(id);
    else ++skipped;
  }
  
  /* if any of these ids exist in the ASTnode replace */
  /* Need a get out if replace fails - shouldnt happen but as a fail-safe */ 
  unsigned int count = 0;
  do 
  {
    for (i = 0; i < lofd->size(); i++)
    {
      replaceFD(node, lofd->get(i), idsToExclude);
    }

    replaced = !(checkFunctionNodeForIds(node, ids));
    count++;
  } 
  while (!replaced && count < 2*(lofd->size() - skipped));
}

void
SBMLTransforms::replaceFD(ASTNode * node, const FunctionDefinition *fd, const IdList* idsToExclude /*= NULL*/)
{
  if ((node == NULL) || (fd == NULL))
    return;
  
  recurseReplaceFD(node, fd, idsToExclude);

}


void
SBMLTransforms::recurseReplaceFD(ASTNode * node, const FunctionDefinition *fd, const IdList* idsToExclude /*= NULL*/)
{
  if ((node == NULL) || (fd == NULL))
    return;

  if (node->isFunction()
    && node->getName() != NULL
      && node->getName() == fd->getId()
      && (idsToExclude == NULL || !idsToExclude->contains(fd->getId())))
  {
   replaceBvars(node, fd);
   for (unsigned int j = 0; j < node->getNumChildren(); j++)
   {
     recurseReplaceFD(node->getChild(j), fd, idsToExclude);
   }
  }
  else
  {
    for (unsigned int i = 0; i < node->getNumChildren(); i++)
    {
      recurseReplaceFD(node->getChild(i), fd, idsToExclude);
    }
  }
}


void
SBMLTransforms::replaceBvars(ASTNode * node, const FunctionDefinition *fd)
{
  if (node==NULL) return;
  if (fd==NULL) return;

  ASTNode fdMath(AST_UNKNOWN);
  unsigned int noBvars;

  if (fd->isSetMath() && fd->getBody() != NULL)
  {
    noBvars = fd->getMath()->getNumBvars();
    fdMath = *fd->getBody();

    // get names of bvars and AST node to substitute for each
    std::vector<std::string> bVars;
    std::vector<ASTNode*> astNodes;
    for (unsigned int i = 0; i < noBvars; ++i){
        bVars.push_back(fd->getArgument(i)->getName());
        astNodes.push_back(node->getChild(i));
    }
    fdMath.replaceArguments(bVars, astNodes);
    (*node) = fdMath;
  }

}


bool
SBMLTransforms::checkFunctionNodeForIds(ASTNode * node, IdList& ids)
{
  bool present = false;
  if (node == NULL) return present;

  unsigned int i = 0;
  unsigned int numChildren = node->getNumChildren();

  if (node->getType() == AST_FUNCTION)
  {
    if (ids.contains(node->getName()))
    {
      present = true;
    }
  }

  while (!present && i < numChildren)
  {
    present = checkFunctionNodeForIds(node->getChild(i), ids);
    i++;
  }
  
  return present;
}


bool
SBMLTransforms::nodeContainsId(const ASTNode * node, IdList& ids)
{
  if (node == NULL) {
    return false;
  }
  bool present = false;
  unsigned int i = 0;
  unsigned int numChildren = node->getNumChildren();

  if (node != NULL && node->getType() == AST_NAME)
  {
    if (ids.contains(node->getName()))
    {
      present = true;
    }
  }

  while (!present && i < numChildren)
  {
    present = nodeContainsId(node->getChild(i), ids);
    i++;
  }
  
  return present;
}

bool
SBMLTransforms::nodeContainsNameNotInList(const ASTNode * node, IdList& ids)
{
  if (node == NULL) {
    return false;
  }
  bool notInList = false;
  unsigned int i = 0;
  unsigned int numChildren = node->getNumChildren();

  if (node != NULL && node->getType() == AST_NAME)
  {
    if (!(ids.contains(node->getName())))
    {
      notInList = true;
    }
  }

  while (!notInList && i < numChildren)
  {
    notInList = nodeContainsNameNotInList(node->getChild(i), ids);
    i++;
  }
  
  return notInList;
}

IdList 
SBMLTransforms::mapComponentValues(const Model * m)
{
	IdValueMap values;
  IdList result = getComponentValuesForModel(m, values);
  mModelValues.erase(m);
  mModelValues.insert(std::make_pair(m, values));
  return result;
}

/**
 * this function checks whether for the given id there exists an initial 
 * assignment and whether it needs to be evaluated or whether the objects
 * initial value can be taken
 * 
 * 
 */
bool shouldUseInitialValue(const std::string& id, const Model * m, bool isL3V2)
{
  const Rule * r = m->getRule(id);
  bool dontHaveUsableRule = (r == NULL) || (r->getType() == RULE_TYPE_RATE);
  if (r != NULL && isL3V2 && !r->isSetMath()) dontHaveUsableRule = true;

  const InitialAssignment* ia = m->getInitialAssignment(id);
  bool dontHaveUsableAssignmentRule = (ia == NULL);
  if (ia != NULL && isL3V2 && !ia->isSetMath()) dontHaveUsableAssignmentRule = true;

  return dontHaveUsableRule && dontHaveUsableAssignmentRule;
}

IdList
SBMLTransforms::getComponentValuesForModel(const Model * m, IdValueMap& values)
{
  values.clear();
  /* it is possible that a model does not have all 
   * the necessary values specified
   * in which case we can not calculate other values
   * keep a list so we can check
   */
  IdList ids;

  if (m == NULL)
    return ids;

  bool isL3V2 = m->getLevel() == 3 && m->getVersion() == 2;

  unsigned int i, j;
  for (i = 0; i < m->getNumCompartments(); i++)
  {
    const Compartment* c = m->getCompartment(i);

    /* is value assigned by an assignmentRule
     * or an initialAssignment
     * or specified
     * - if none then the model is incomplete
     */
    if (shouldUseInitialValue(c->getId(), m, isL3V2))
    {
      /* not set by assignment */
      if (!(c->isSetSize()))
      {
        ids.append(c->getId());
        ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
        values.insert(pair<const std::string, ValueSet>(c->getId(), v));
      }
      else
      {
        ValueSet v = make_pair(c->getSize(), true);
        values.insert(pair<const std::string, ValueSet>(c->getId(), v));
      }
    }
    else
    {
      /* is set by assignment - need to work it out */
      ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
      values.insert(pair<const std::string, ValueSet>(c->getId(), v));
    }
  }

  for (i = 0; i < m->getNumSpecies(); i++)
  {
    const Species * s = m->getSpecies(i);
    /* is value assigned by an assignmentRule
     * or an initialAssignment
     * or specified
     * - if none then the model is incomplete
     */
    if (shouldUseInitialValue(s->getId(), m, isL3V2))
    {
      if (!(s->isSetInitialAmount()) && !(s->isSetInitialConcentration()))
      {
        ids.append(s->getId());
        ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
        values.insert(pair<const std::string, ValueSet>(s->getId(), v));
      }
      else
      {
        /* here need to be careful as the id will refer to concentration
         * unless hasOnlySubstanceUnits is true
         * regardless of whether amount/concentration has been set
         */
        if (s->getHasOnlySubstanceUnits())
        {
          ValueSet v = make_pair(s->getInitialAmount(), true);
          values.insert(pair<const std::string, ValueSet>(s->getId(), v));
        }
        else if (s->isSetInitialAmount())
        {
          /* at present only deal with case where compartment size is fixed */
          IdValueIter it;
          it = values.find(s->getCompartment());
          if (it != values.end())
          {
            /* compartment size is set */
            if (((*it).second).second)
            {
              double conc = s->getInitialAmount()/(((*it).second).first);
              ValueSet v = make_pair(conc, true);
              values.insert(pair<const std::string, ValueSet>(s->getId(), v));
            }
            else
            {
              ids.append(s->getId());
              ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
              values.insert(pair<const std::string, ValueSet>(s->getId(), v));
            }
          }
          else
          {
            ids.append(s->getId());
            ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
            values.insert(pair<const std::string, ValueSet>(s->getId(), v));
          }
        }
        else
        {
          ValueSet v = make_pair(s->getInitialConcentration(), true);
          values.insert(pair<const std::string, ValueSet>(s->getId(), v));
        }

      }
    }
    else
    {
      /* is set by assignment - need to work it out */
      ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
      values.insert(pair<const std::string, ValueSet>(s->getId(), v));
    }
  }

  for (i = 0; i < m->getNumParameters(); i++)
  {
    const Parameter * p = m->getParameter(i);

    /* is value assigned by an assignmentRule
     * or an initialAssignment
     * or specified
     * - if none then the model is incomplete
     */
    if (shouldUseInitialValue(p->getId(), m, isL3V2))
    {
      if (!(p->isSetValue()))
      {
        ids.append(p->getId());
        ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
        values.insert(pair<const std::string, ValueSet>(p->getId(), v));
      }
      else
      {
        ValueSet v = make_pair(p->getValue(), true);
        values.insert(pair<const std::string, ValueSet>(p->getId(), v));
      }
    }
    else
    {
      /* is set by assignment - need to work it out */
      ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
      values.insert(pair<const std::string, ValueSet>(p->getId(), v));
    }
  }

  for (i = 0; i < m->getNumReactions(); i++)
  {
    const Reaction *rn = m->getReaction(i);

    for (j = 0; j < rn->getNumReactants(); j++)
    {
      const SpeciesReference * sr = rn->getReactant(j);

      /* is value assigned by an assignmentRule
      * or an initialAssignment
      * or specified
      * - if none then the model is incomplete
      */
      if (shouldUseInitialValue(sr->getId(), m, isL3V2) &&
          !( sr->isSetStoichiometryMath() && sr->getStoichiometryMath()->isSetMath() ) )
      {
        /* not set by assignment */
        if (sr->isSetStoichiometry() == false && m->getLevel() > 2 )
        {
          ids.append(sr->getId());
          ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
        else
        {
          ValueSet v = make_pair(sr->getStoichiometry(), true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
      }
      else
      {
        if (sr->isSetStoichiometryMath())
        {
          ValueSet v = make_pair(
            evaluateASTNode(sr->getStoichiometryMath()->getMath(), values, m), 
            true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
        else
        {
          /* is set by assignment - need to work it out */
          ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
      }
    }

    for(j = 0; j < rn->getNumProducts(); j++)
    {
      const SpeciesReference * sr = rn->getProduct(j);
      /* is value assigned by an assignmentRule
      * or an initialAssignment
      * or specified
      * - if none then the model is incomplete
      */
      if (shouldUseInitialValue(sr->getId(), m, isL3V2) &&
         !sr->isSetStoichiometryMath())
      {
        /* not set by assignment */
        if (!(sr->isSetStoichiometry()))
        {
          ids.append(sr->getId());
          ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), false);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
        else
        {
          ValueSet v = make_pair(sr->getStoichiometry(), true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
      }
      else
      {
        if (sr->isSetStoichiometryMath())
        {
          ValueSet v = make_pair(
            evaluateASTNode(sr->getStoichiometryMath()->getMath(), values, m),
            true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
        else
        {
          /* is set by assignment - need to work it out */
          ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
          values.insert(pair<const std::string, ValueSet>(sr->getId(), v));
        }
      }
    }

    // the id of a reaction might be used
    ValueSet v = make_pair(numeric_limits<double>::quiet_NaN(), true);
    values.insert(pair<const std::string, ValueSet>(rn->getId(), v));

  }

  /* returns a list of ids for which the model has no declared value
   * and no assignment
   */
  return ids;
}

SBMLTransforms::IdValueMap
SBMLTransforms::getComponentValues(const Model* m)
{
  return mModelValues[m];
}

IdList 
SBMLTransforms::getComponentIds(const Model* m)
{
  IdList result;
  IdValueMap values = mModelValues[m];
  for (IdValueMap::iterator i = values.begin(); i != values.end(); ++i)
  {
		result.append(i->first);
	}
  return result;
}


void 
SBMLTransforms::clearComponentValues(const Model* m)
{
  if (!m)
  {
    // clear all maps if no model specified
    mModelValues.clear();
    return;
  }

  // otherwise remove only specific set
  if (!mModelValues.empty()) {
      mModelValues.erase(m);
  }
}



double
SBMLTransforms::evaluateASTNode(const ASTNode *node, const Model *m)
{
  if (m)
  {
    IdValueMap values = mModelValues[m];
    if (values.size() == 0)
    {
      mapComponentValues(m);
    }
  }
  return evaluateASTNode(node, mModelValues[m], m);
}

double 
SBMLTransforms::evaluateASTNode(const ASTNode * node, const std::map<std::string, double>& values, const Model * m)
{
  IdValueMap currentSet;
  std::map<std::string, double>::const_iterator it = values.begin();
  while (it != values.end())
  {
    ValueSet v = make_pair(it->second, false);
    currentSet.insert(pair<const std::string, ValueSet>(it->first, v));
    ++it;
  }
  return evaluateASTNode(node, currentSet, m);
}

double
SBMLTransforms::evaluateASTNode(const ASTNode * node, const IdValueMap& values, const Model * m)
{
  if (node == NULL) {
    return numeric_limits<double>::quiet_NaN();
  }
  double result = 0;
  int i;
  const ListOfFunctionDefinitions *lfd = NULL;
  ASTNode *tempNode = NULL;

  switch (node->getType())
  {
  case AST_INTEGER:
    result = (double) (node->getInteger());
    break;

  case AST_REAL:
    result = node->getReal();
    break;

  case AST_REAL_E:
    result = node->getReal();
    break;

  case AST_RATIONAL:
    result = node->getReal();
    break;
  
  case AST_NAME:
    if (!values.empty())
    {
      if (values.find(node->getName()) != values.end())
      {
        result = (values.find(node->getName())->second).first;
        bool set = (values.find(node->getName())->second).second;
        if (util_isNaN(result) && set)
        {
          if (m != NULL)
          {
            // means the value is set by a rule/initialAssignment
            const Rule *r = m->getRule(node->getName());
            const InitialAssignment *ia = 
                                m->getInitialAssignment(node->getName());
            const Reaction *rn = m->getReaction(node->getName()); 
            if (r != NULL)
            {
              result = evaluateASTNode(r->getMath(), values, m);
            }
            else if (ia != NULL)
            {
              result = evaluateASTNode(ia->getMath(), values, m);
            }
            else if (rn != NULL && rn->isSetKineticLaw())
            {
              result = evaluateASTNode(rn->getKineticLaw()->getMath(), values, m);
            }
          }
        }
      }
      else
      {
        result = numeric_limits<double>::quiet_NaN();
      }
    }
    else
      result = numeric_limits<double>::quiet_NaN();
    break;

  case AST_NAME_AVOGADRO:
    result = node->getReal();
    break;

  case AST_NAME_TIME:
    result = 0.0;
    break;

  case AST_CONSTANT_E:
    /* exp(1) is used to adjust exponentiale to machine precision */
    result = exp(1.0);
    break;

  case AST_CONSTANT_FALSE:
    result = 0.0;
    break;

  case AST_CONSTANT_PI:
    /* pi = 4 * atan 1  is used to adjust Pi to machine precision */
    result = 4.0*atan(1.0);
    break;

  case AST_CONSTANT_TRUE:
    result = 1.0;
    break;

  case AST_LAMBDA:
    /* shouldnt get here */
    result = numeric_limits<double>::quiet_NaN();
    break;

  case AST_FUNCTION:
    /* shouldnt get here */
    // but we do if math we are expanding uses a functionDefinition
    {
        if(m != NULL){
            lfd = m->getListOfFunctionDefinitions();
        }
        if (lfd != NULL && lfd->get(node->getName()) != NULL)
        {
            tempNode = node->deepCopy();
            replaceFD(tempNode, lfd);
            result = evaluateASTNode(tempNode, values, m);
            delete tempNode;
        }
        else
        {
            result = numeric_limits<double>::quiet_NaN();
        }
        break;
    }

  case AST_PLUS:
    if (node->getNumChildren() == 0)
    {
      result = 0.0;
    }
    else if (node->getNumChildren() == 1)
    {
      result = evaluateASTNode(node->getChild(0), values, m);
    }
    else
    {
      result = evaluateASTNode(node->getChild(0), values, m);
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
      {
        result = result + evaluateASTNode(node->getChild(j), values, m) ;
      }
    }
    break;

  case AST_MINUS:
    if(node->getNumChildren() == 1)
      result = -(evaluateASTNode(node->getChild(0), values, m));
    else
      result = evaluateASTNode(node->getChild(0), values, m) -
      evaluateASTNode(node->getChild(1), values, m);
    break;

  case AST_TIMES:
    if (node->getNumChildren() == 0)
    {
      result = 1.0;
    }
    else if (node->getNumChildren() == 1)
    {
      result = evaluateASTNode(node->getChild(0), values, m);
    }
    else
    {
      result = evaluateASTNode(node->getChild(0), values, m);
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
      {
        result = result * evaluateASTNode(node->getChild(j), values, m) ;
      }
    }
    break;

  case AST_DIVIDE:
    result = evaluateASTNode(node->getChild(0), values, m) /
      evaluateASTNode(node->getChild(1), values, m);
    break;

  case AST_POWER:
  case AST_FUNCTION_POWER:
    result = pow(evaluateASTNode(node->getChild(0), values, m),
      evaluateASTNode(node->getChild(1), values, m));
    break;

  case AST_FUNCTION_ABS:
    result = (double)(fabs((double)(evaluateASTNode(node->getChild(0), values, m))));
    break;

  case AST_FUNCTION_ARCCOS:
    result = acos(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCCOSH:
    /* arccosh(x) = ln(x + sqrt(x-1).sqrt(x+1)) */
    result = log(evaluateASTNode(node->getChild(0), values, m)
      + pow((evaluateASTNode(node->getChild(0), values, m) - 1), 0.5)
      * pow((evaluateASTNode(node->getChild(0), values, m) + 1), 0.5));
    break;

  case AST_FUNCTION_ARCCOT:
    /* arccot x =  arctan (1 / x) */
    result = atan(1.0 / evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCCOTH:
    /* arccoth x = 1/2 * ln((x+1)/(x-1)) */
    result = ((1.0 / 2.0) * log((evaluateASTNode(node->getChild(0), values, m) + 1.0)
      / (evaluateASTNode(node->getChild(0), values, m) - 1.0)));
    break;

  case AST_FUNCTION_ARCCSC:
    /* arccsc(x) = Arcsin(1 / x) */
    result = asin(1.0 / evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCCSCH:
    /* arccsch(x) = ln((1 + sqrt(1 + x^2)) / x) */
    result = log((1.0 + pow(1.0 + 
      pow(evaluateASTNode(node->getChild(0), values, m), 2), 0.5))
      / evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCSEC:
    /* arcsec(x) = arccos(1/x) */
    result = acos(1.0 / evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCSECH:
    /* arcsech(x) = ln((1 + sqrt(1 - x^2)) / x) */
    result = log((1.0 + pow((1.0 - 
      pow(evaluateASTNode(node->getChild(0), values, m), 2)), 0.5))
      / evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCSIN:
    result = asin(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCSINH:
    /* arcsinh(x) = ln(x + sqrt(1 + x^2)) */
    result = log(evaluateASTNode(node->getChild(0), values, m)
      + pow((1.0 + pow(evaluateASTNode(node->getChild(0), values, m), 2)), 0.5));
    break;

  case AST_FUNCTION_ARCTAN:
    result = atan(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_ARCTANH:
    /* arctanh = 0.5 * ln((1+x)/(1-x)) */
    result = 0.5 * log((1.0 + evaluateASTNode(node->getChild(0), values, m))
      / (1.0 - evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_FUNCTION_CEILING:
    result = ceil(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_COS:
    result = cos(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_COSH:
    result = cosh(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_COT:
    /* cot x = 1 / tan x */
    result = (1.0 / tan(evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_FUNCTION_COTH:
    /* coth x = cosh x / sinh x */
    result = cosh(evaluateASTNode(node->getChild(0), values, m)) /
      sinh(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_CSC:
    /* csc x = 1 / sin x */
    result = (1.0 / sin(evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_FUNCTION_CSCH:
    /* csch x = 1 / sinh x  */
    result = (1.0 / sinh(evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_FUNCTION_DELAY:
    result = numeric_limits<double>::quiet_NaN();
    break;

  case AST_FUNCTION_EXP:
    result = exp(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_FACTORIAL:
    i = (int)(floor(evaluateASTNode(node->getChild(0), values, m)));
    result = 1;
    for(; i>1; --i)
    {
      result *= i;
    }
    break;

  case AST_FUNCTION_FLOOR:
    result = floor(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_LN:
    result = log(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_LOG:
    result = log10(evaluateASTNode(node->getChild(1), values, m));
    break;

  case AST_FUNCTION_PIECEWISE:    
    {
      unsigned int numChildren = node->getNumChildren();
      if ( numChildren % 2 == 0)
      {
        bool assigned = false;
        for (unsigned int j = 0; j < numChildren; j+=2)
        {
          // compute piece
          double value = evaluateASTNode(node->getChild(j), values, m);
          double boolean = evaluateASTNode(node->getChild(j + 1), values, m);
          if (boolean == 1.0)
          {
            // we might have two true piece statements
            // if the values are the same - fine
            // if not then the result is undefined
            if (assigned == true)
            {
              if (value == result)
              {
                continue;
              }
              else
              {
                result = numeric_limits<double>::quiet_NaN();
              }
            }
            else
            {
              result = value;
              assigned = true;
            }
          }
        }
        if (!assigned)
        {
          result = numeric_limits<double>::quiet_NaN();
        }
      }
      else
      {
        bool assigned = false;
        for (unsigned int j = 0; j < numChildren-1; j+=2)
        {
          // compute piece
          double value = evaluateASTNode(node->getChild(j), values, m);
          double boolean = evaluateASTNode(node->getChild(j + 1), values, m);
          if (boolean == 1.0)
          {
            // we might have two true piece statements
            // if the values are the same - fine
            // if not then the result is undefined
            if (assigned == true)
            {
              if (value == result)
              {
                continue;
              }
              else
              {
                result = numeric_limits<double>::quiet_NaN();
              }
            }
            else
            {
              result = value;
              assigned = true;
            }
           }
        }
        if (!assigned)
        {
          // compute otherwise
          result = evaluateASTNode(node->getChild(numChildren - 1), values, m);
        }
      }
    }
    break;

  case AST_FUNCTION_ROOT:
    result = pow(evaluateASTNode(node->getChild(1), values, m),
      (1.0 / evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_FUNCTION_SEC:
    /* sec x = 1 / cos x */
    result = 1.0 / cos(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_SECH:
    /* sech x = 1 / cosh x */
    result = 1.0 / cosh(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_SIN:
    result = sin(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_SINH:
    result = sinh(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_TAN:
    result = tan(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_FUNCTION_TANH:
    result = tanh(evaluateASTNode(node->getChild(0), values, m));
    break;

  case AST_LOGICAL_AND:
    {
      if (node->getNumChildren() == 0)
        result = 1.0;
      else if (node->getNumChildren() == 1)
        result = evaluateASTNode(node->getChild(0), values, m);
      else
        result = (double)((evaluateASTNode(node->getChild(0), values, m))
        && (evaluateASTNode(node->getChild(1), values, m)));
    }
    break;

  case AST_LOGICAL_NOT:
    result = (double)(!(evaluateASTNode(node->getChild(0), values, m)));
    break;

  case AST_LOGICAL_OR:
    {
      if (node->getNumChildren() == 0)
        result = 0.0;
      else if (node->getNumChildren() == 1)
        result = evaluateASTNode(node->getChild(0), values, m);
      else
        result = (double)((evaluateASTNode(node->getChild(0), values, m))
        || (evaluateASTNode(node->getChild(1), values, m)));
    }
    break;

  case AST_LOGICAL_XOR:
    {
      if (node->getNumChildren() == 0)
        result = 0.0;
      else if (node->getNumChildren() == 1)
        result = evaluateASTNode(node->getChild(0), values, m);
      else
        result = (double)((!(evaluateASTNode(node->getChild(0), values, m))
        && (evaluateASTNode(node->getChild(1), values, m)))
        || ((evaluateASTNode(node->getChild(0), values, m))
        && !(evaluateASTNode(node->getChild(1), values, m))));
    }
    break;

  case AST_RELATIONAL_EQ :
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
        result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
        == (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  case AST_RELATIONAL_GEQ:
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
        result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
        >= (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  case AST_RELATIONAL_GT:
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
        result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
        > (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  case AST_RELATIONAL_LEQ:
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
         result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
         <= (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  case AST_RELATIONAL_LT :
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
        result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
        < (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  case AST_RELATIONAL_NEQ :
    if (node->getNumChildren() < 2) result = 0.0;
    else 
    {      
      result = 1.0;
      for (unsigned int j = 1; j < node->getNumChildren(); ++j)
        result *= (double)((evaluateASTNode(node->getChild(j-1), values, m))
        != (evaluateASTNode(node->getChild(j), values, m)));
    }
    break;

  default:
    if (node->getNumPlugins() == 0)
    {
      ((ASTNode*)(node))->loadASTPlugins(NULL);
    }
    for (unsigned int p = 0; p < node->getNumPlugins(); p++)
    {
      const ASTBasePlugin* baseplugin = node->getPlugin(p);
      if (baseplugin->defines(node->getType()))
      {
        result = baseplugin->evaluateASTNode(node, m);
      }
    }
  }


  return result;
}

bool
SBMLTransforms::expandIA(Model* m, const InitialAssignment* ia)
{
  bool removed = false;
  std::string id = ia->getSymbol();
  if (m->getCompartment(id) != NULL) 
  {
    if (expandInitialAssignment(m->getCompartment(id), 
                                ia))
    {
      delete m->removeInitialAssignment(id);
      removed = true;
    }
  }
  else if (m->getParameter(id) != NULL)
  {
    if (expandInitialAssignment(m->getParameter(id), 
                                ia))
    {
      delete m->removeInitialAssignment(id);
      removed = true;
    }
  }
  else if (m->getSpecies(id) != NULL)
  {
    if (expandInitialAssignment(m->getSpecies(id), 
                                ia))
    {
      delete m->removeInitialAssignment(id);
      removed = true;
    }
  }
  else 
  {
    for (unsigned int j = 0; j < m->getNumReactions(); j++)
    {
      Reaction * r = m->getReaction(j);
      unsigned int k;
      for (k = 0; k < r->getNumProducts(); k++)
      {
        if (r->getProduct(k)->getId() == id)
        {
          if (expandInitialAssignment(r->getProduct(k), 
                                      ia))
          {
            delete m->removeInitialAssignment(id);
            removed = true;
          }
        }
      }
      for (k = 0; k < r->getNumReactants(); k++)
      {
        if (r->getReactant(k)->getId() == id)
        {
          if (expandInitialAssignment(r->getReactant(k), 
                                      ia))
          {
            delete m->removeInitialAssignment(id);
            removed = true;
          }
        }
      }
    }
  }

  return removed;
}

bool 
SBMLTransforms::expandInitialAssignments(Model * m)
{
  IdList idsNoValues = mapComponentValues(m);
  IdList idsWithValues;
  IdValueMap values = mModelValues[m];

  IdValueIter iter;
  bool needToBail = false;
  unsigned int count;

  do
  {
    /* need a fail safe in case a value is just missing */
    unsigned int num = m->getNumInitialAssignments();
    count = num;
    
    /* list ids that have a calculated/assigned value */
    idsWithValues.clear();
    for (iter = values.begin(); iter != values.end(); ++iter)
    {
      if (((*iter).second).second)
      {
        idsWithValues.append((*iter).first);
      }
    }

    for (int i = num-1; i >= 0; i--)
    {
      if (m->getInitialAssignment(i)->isSetMath())
      {
        if (!nodeContainsId(m->getInitialAssignment(i)->getMath(), idsNoValues))
        {
          if (!nodeContainsNameNotInList(m->getInitialAssignment(i)->getMath(), 
                                                                   idsWithValues))
          {
            bool removed = expandIA(m, m->getInitialAssignment(i));
            if (removed) count--;
          }
        }
        else
        {
          needToBail = true;
        }
      }
      else
      {
        count--;
      }
    }
    /* if count is still same nothing changed so bail or endlessly loop */
    if (count == num)
    {
      needToBail = true;
    }
  }
  while(count > 0 && needToBail == false);

  // clear the internal map of values
  clearComponentValues(m);

  return true;
}


bool 
SBMLTransforms::expandL3V2InitialAssignments(Model * m)
{
  IdList idsNoValues = mapComponentValues(m);
  IdValueMap values = mModelValues[m];
  IdList idsWithValues;

  IdValueIter iter;
  bool needToBail = false;
  unsigned int count;

  do
  {
    /* need a fail safe in case a value is just missing */
    unsigned int num = m->getNumInitialAssignments();
    count = num;
    
    /* list ids that have a calculated/assigned value */
    idsWithValues.clear();
    for (iter = values.begin(); iter != values.end(); ++iter)
    {
      if (((*iter).second).second)
      {
        idsWithValues.append((*iter).first);
      }
    }

    for (int i = num-1; i >= 0; i--)
    {
      const InitialAssignment* ia = m->getInitialAssignment(i);
      // we only want to do something if the initial assignment uses l3v2 math
      if (ia->isSetMath() && ia->getMath()->usesL3V2MathConstructs() && !ia->getMath()->usesRateOf())
      {
        if (!nodeContainsId(ia->getMath(), idsNoValues))
        {
          if (!nodeContainsNameNotInList(ia->getMath(), idsWithValues))
          {
            bool removed = expandIA(m, ia);
            if (removed) count--;
          }
        }
        else
        {
          needToBail = true;
        }
      }
      else
      {
        count--;
      }
    }
    /* if count is still same nothing changed so bail or endlessly loop */
    if (count == num)
    {
      needToBail = true;
    }
  }
  while(count > 0 && needToBail == false);

  // clear the internal map of values
  clearComponentValues(m);

  return true;
}


bool 
SBMLTransforms::expandInitialAssignment(Compartment * c, 
    const InitialAssignment *ia)
{
  bool success = false; 
  double value = evaluateASTNode(ia->getMath(), c->getModel());
  if (!util_isNaN(value))
  {
    c->setSize(value);
    IdValueIter it = mModelValues[c->getModel()].find(c->getId());
    ((*it).second).first = value;
    ((*it).second).second = true;
    success = true;
  }

  return success;
}

bool 
SBMLTransforms::expandInitialAssignment(Parameter * p, 
    const InitialAssignment *ia)
{
  bool success = false; 
  double value = evaluateASTNode(ia->getMath(), p->getModel());
  if (!util_isNaN(value))
  {
    p->setValue(value);
    IdValueIter it = mModelValues[p->getModel()].find(p->getId());
    ((*it).second).first = value;
    ((*it).second).second = true;
    success = true;
  }

  return success;
}

bool 
SBMLTransforms::expandInitialAssignment(SpeciesReference * sr, 
    const InitialAssignment *ia)
{
  bool success = false; 
  double value = evaluateASTNode(ia->getMath(), sr->getModel());
  if (!util_isNaN(value))
  {
    sr->setStoichiometry(value);
    IdValueIter it = mModelValues[sr->getModel()].find(sr->getId());
    ((*it).second).first = value;
    ((*it).second).second = true;
    success = true;
  }

  return success;
}

bool 
SBMLTransforms::expandInitialAssignment(Species * s, 
    const InitialAssignment *ia)
{
  bool success = false; 
  double value = evaluateASTNode(ia->getMath(), s->getModel());
  if (!util_isNaN(value))
  {
    if (s->getHasOnlySubstanceUnits())
    {
      s->setInitialAmount(value);
    }
    else
    {
      s->setInitialConcentration(value);
    }

    IdValueIter it = mModelValues[s->getModel()].find(s->getId());
    ((*it).second).first = value;
    ((*it).second).second = true;
    success = true;
  }

  return success;
}
/** @endcond */

#endif /* __cplusplus */
/** @cond doxygenIgnored */
/** @endcond */

LIBSBML_CPP_NAMESPACE_END
