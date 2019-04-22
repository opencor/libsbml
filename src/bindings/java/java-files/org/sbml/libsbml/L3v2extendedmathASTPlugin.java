/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/** 
 *  Extension of AST.
 */

public class L3v2extendedmathASTPlugin extends ASTBasePlugin {
   private long swigCPtr;

   protected L3v2extendedmathASTPlugin(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.L3v2extendedmathASTPlugin_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(L3v2extendedmathASTPlugin obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (L3v2extendedmathASTPlugin obj)
   {
     long ptr = 0;

     if (obj != null)
     {
       ptr             = obj.swigCPtr;
       obj.swigCMemOwn = false;
     }

     return ptr;
   }

  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        libsbmlJNI.delete_L3v2extendedmathASTPlugin(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }

  
/**
   * Creates a new {@link L3v2extendedmathASTPlugin} object.
   */ public
 L3v2extendedmathASTPlugin() {
    this(libsbmlJNI.new_L3v2extendedmathASTPlugin__SWIG_0(), true);
  }

  
/** */ public
 L3v2extendedmathASTPlugin(L3v2extendedmathASTPlugin orig) {
    this(libsbmlJNI.new_L3v2extendedmathASTPlugin__SWIG_1(L3v2extendedmathASTPlugin.getCPtr(orig), orig), true);
  }

  
/**
  * Creates and returns a deep copy of this {@link L3v2extendedmathASTPlugin} object.
  <p>
  * @return the (deep) copy of this {@link L3v2extendedmathASTPlugin} object.
  */ public
 ASTBasePlugin cloneObject() {
    long cPtr = libsbmlJNI.L3v2extendedmathASTPlugin_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new L3v2extendedmathASTPlugin(cPtr, true);
  }

  
/** */ public
 boolean hasCorrectNamespace(SBMLNamespaces namespaces) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_hasCorrectNamespace(swigCPtr, this, SBMLNamespaces.getCPtr(namespaces), namespaces);
  }

  
/** */ public
 L3v2extendedmathASTPlugin(String uri) {
    this(libsbmlJNI.new_L3v2extendedmathASTPlugin__SWIG_2(uri), true);
  }

  
/** */ public
 int checkNumArguments(ASTNode function, SWIGTYPE_p_std__stringstream error) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_checkNumArguments(swigCPtr, this, ASTNode.getCPtr(function), function, SWIGTYPE_p_std__stringstream.getCPtr(error));
  }

  
/** */ public
 double evaluateASTNode(ASTNode node, Model m) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_evaluateASTNode__SWIG_0(swigCPtr, this, ASTNode.getCPtr(node), node, Model.getCPtr(m), m);
  }

  
/** */ public
 double evaluateASTNode(ASTNode node) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_evaluateASTNode__SWIG_1(swigCPtr, this, ASTNode.getCPtr(node), node);
  }

  
/** 
   * returns the unitDefinition for the {@link ASTNode} from a rem function
   */ public
 UnitDefinition getUnitDefinitionFromRem(SWIGTYPE_p_UnitFormulaFormatter uff, ASTNode node, boolean inKL, int reactNo) {
    long cPtr = libsbmlJNI.L3v2extendedmathASTPlugin_getUnitDefinitionFromRem(swigCPtr, this, SWIGTYPE_p_UnitFormulaFormatter.getCPtr(uff), ASTNode.getCPtr(node), node, inKL, reactNo);
    return (cPtr == 0) ? null : new UnitDefinition(cPtr, false);
  }

  
/** 
   * returns the unitDefinition for the {@link ASTNode} from a rateOf function
   */ public
 UnitDefinition getUnitDefinitionFromRateOf(SWIGTYPE_p_UnitFormulaFormatter uff, ASTNode node, boolean inKL, int reactNo) {
    long cPtr = libsbmlJNI.L3v2extendedmathASTPlugin_getUnitDefinitionFromRateOf(swigCPtr, this, SWIGTYPE_p_UnitFormulaFormatter.getCPtr(uff), ASTNode.getCPtr(node), node, inKL, reactNo);
    return (cPtr == 0) ? null : new UnitDefinition(cPtr, false);
  }

  
/** */ public
 UnitDefinition getUnitDefinitionFromPackage(SWIGTYPE_p_UnitFormulaFormatter uff, ASTNode node, boolean inKL, int reactNo) {
    long cPtr = libsbmlJNI.L3v2extendedmathASTPlugin_getUnitDefinitionFromPackage(swigCPtr, this, SWIGTYPE_p_UnitFormulaFormatter.getCPtr(uff), ASTNode.getCPtr(node), node, inKL, reactNo);
    return (cPtr == 0) ? null : new UnitDefinition(cPtr, false);
  }

  
/** */ public
 boolean isLogical(int type) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_isLogical(swigCPtr, this, type);
  }

  
/**
   * Check if the node type is known to be allowed inside function definitions.
   <p>
   * Function definitions must be able to be evaluated without resort to outside information.
   * Therefore, some ASTNodes (like AST_TIME and AST_FUNCTION_RATE_OF) are disallowed
   * from appearing there.  This function checks whether this is true for a given type:
   * a return value of '-1' means the plugin has no knowledge of that type; a return
   * value of '1' means the plugin knows that the type is indeed allowed, and a
   * return value of '0' means that the plugin knows that the type is not allowed.
   */ public
 int allowedInFunctionDefinition(int type) {
    return libsbmlJNI.L3v2extendedmathASTPlugin_allowedInFunctionDefinition(swigCPtr, this, type);
  }

}
