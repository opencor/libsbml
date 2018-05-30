//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace libsbml {

 using System;
 using System.Runtime.InteropServices;

/** 
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html Base class for extending SBML components
 *
 * @htmlinclude not-sbml-warning.html
 *
 * @ifnot clike @internal @endif
 *
 *
 * 
 * This class is used as part of the mechanism that connects plugin objects
 * (implemented using SBasePlugin or SBMLDocumentPlugin) to a given package
 * extension.  For instance, an implementation of an extended version of
 * Model (e.g., LayoutModelPlugin in the %Layout package) would involve the
 * creation of an extension point using SBaseExtensionPoint and a mediator
 * object created using SBasePluginCreator, to 'plug' the extended Model
 * object (LayoutModelPlugin) into the overall LayoutExtension object.
 *
 * The use of SBaseExtensionPoint is relatively straightforward.  The
 * class needs to be used for each extended SBML object implemented using
 * SBMLDocumentPlugin or SBasePlugin.  Doing so requires knowing just two
 * things:
 *
 * @li The short-form name of the @em parent package being extended.  The
 * parent package is often simply core SBML, identified in libSBML by the
 * nickname <code>'core'</code>, but a SBML Level&nbsp;3 package could
 * conceivably extend another Level&nbsp;3 package.
 *
 * @li The libSBML type code assigned to the object being extended.  For
 * example, if an extension of Model is implemented, the relevant type code
 * is #SBML_MODEL, found in #SBMLTypeCode_t.
 *
 * The typical use of SBaseExtensionPoint is illustrated by the following
 * code fragment:
 *
 * @code{.cpp}
 * SBaseExtensionPoint docExtPoint('core', SBML_DOCUMENT);
 * SBaseExtensionPoint modelExtPoint('core', SBML_MODEL);
 *
 * SBasePluginCreator<GroupsSBMLDocumentPlugin, GroupsExtension> docPluginCreator(docExtPoint, pkgURIs);
 * SBasePluginCreator<GroupsModelPlugin, GroupsExtension> modelPluginCreator(modelExtPoint, pkgURIs);
 * @endcode
 *
 * The code above shows two core SBML components being extended: the
 * document object, and the Model object.  These extended objects are
 * created elsewhere (not shown) as the
 * <code>GroupsSBMLDocumentPlugin</code> and <code>GroupsModelPlugin</code>
 * objects.  The corresponding SBaseExtensionPoint objects are handed as
 * arguments to the constructor for SBasePluginCreator to create the
 * connection between the extended core components and the overall package
 * extension (here, for the Groups package, with the
 * <code>GroupsExtension</code> object).
 *
 * The code above is typically placed in the implementation of the
 * <code>init()</code> method of the package class derived from
 * SBMLExtension.  (For the example above, it would be in the
 * <code>GroupsExtension.cpp</code> file.)
 *
 *
 */

public class SBaseExtensionPoint : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;
	
	internal SBaseExtensionPoint(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}
	
	internal static HandleRef getCPtr(SBaseExtensionPoint obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}
	
	internal static HandleRef getCPtrAndDisown (SBaseExtensionPoint obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);
		
		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}
		
		return ptr;
	}

  ~SBaseExtensionPoint() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBaseExtensionPoint(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  
/**
   * Constructor for SBaseExtensionPoint.
   *
   * The use of SBaseExtensionPoint is relatively straightforward.  The
   * class needs to be used for each extended SBML object implemented
   * using SBMLDocumentPlugin or SBasePlugin.  Doing so requires knowing
   * just two things:
   *
   * @li The short-form name of the @em parent package being extended.
   * The parent package is often simply core SBML, identified in libSBML
   * by the nickname <code>'core'</code>, but a SBML Level&nbsp;3
   * package could conceivably extend another Level&nbsp;3 package and
   * the mechanism supports this.
   *
   * @li The libSBML type code assigned to the object being extended.
   * For example, if an extension of Model is implemented, the relevant
   * type code is SBML_MODEL, found in #SBMLTypeCode_t.
   *
   * @param pkgName the short-form name of the parent package where
   * that this package extension is extending.
   *
   * @param typeCode the type code of the object being extended.
   */ public
 SBaseExtensionPoint(string pkgName, int typeCode) : this(libsbmlPINVOKE.new_SBaseExtensionPoint__SWIG_0(pkgName, typeCode), true) {
  }

  
/**
  * Constructor for SBaseExtensionPoint.
  *
  * The use of SBaseExtensionPoint is relatively straightforward.  The
  * class needs to be used for each extended SBML object implemented
  * using SBMLDocumentPlugin or SBasePlugin.  Doing so requires knowing
  * just two things:
  *
  * @li The short-form name of the @em parent package being extended.
  * The parent package is often simply core SBML, identified in libSBML
  * by the nickname <code>'core'</code>, but a SBML Level&nbsp;3
  * package could conceivably extend another Level&nbsp;3 package and
  * the mechanism supports this.
  *
  * @li The libSBML type code assigned to the object being extended.
  * For example, if an extension of Model is implemented, the relevant
  * type code is SBML_MODEL, found in #SBMLTypeCode_t.
  *
  * @param pkgName the short-form name of the parent package where
  * that this package extension is extending.
  *
  * @param typeCode the type code of the object being extended.
  * 
  * @param elementName element name for the target element, in case 
  * multiple elements match the same type code (as will be the case
  * for ListOf classes).
  *
  * @param elementOnly flag to be used during the registration 
  * of the package, when set then the plugin is only applied to 
  * elements whose elementName match.
  */ public
 SBaseExtensionPoint(string pkgName, int typeCode, string elementName, bool elementOnly) : this(libsbmlPINVOKE.new_SBaseExtensionPoint__SWIG_1(pkgName, typeCode, elementName, elementOnly), true) {
  }

  
/**
  * Constructor for SBaseExtensionPoint.
  *
  * The use of SBaseExtensionPoint is relatively straightforward.  The
  * class needs to be used for each extended SBML object implemented
  * using SBMLDocumentPlugin or SBasePlugin.  Doing so requires knowing
  * just two things:
  *
  * @li The short-form name of the @em parent package being extended.
  * The parent package is often simply core SBML, identified in libSBML
  * by the nickname <code>'core'</code>, but a SBML Level&nbsp;3
  * package could conceivably extend another Level&nbsp;3 package and
  * the mechanism supports this.
  *
  * @li The libSBML type code assigned to the object being extended.
  * For example, if an extension of Model is implemented, the relevant
  * type code is SBML_MODEL, found in #SBMLTypeCode_t.
  *
  * @param pkgName the short-form name of the parent package where
  * that this package extension is extending.
  *
  * @param typeCode the type code of the object being extended.
  * 
  * @param elementName element name for the target element, in case 
  * multiple elements match the same type code (as will be the case
  * for ListOf classes).
  *
  * @param elementOnly flag to be used during the registration 
  * of the package, when set then the plugin is only applied to 
  * elements whose elementName match.
  */ public
 SBaseExtensionPoint(string pkgName, int typeCode, string elementName) : this(libsbmlPINVOKE.new_SBaseExtensionPoint__SWIG_2(pkgName, typeCode, elementName), true) {
  }

  
/**
   * Copy constructor.
   *
   * This creates a copy of an SBaseExtensionPoint instance.
   *
   * @param rhs the object to copy.
   */ public
 SBaseExtensionPoint(SBaseExtensionPoint rhs) : this(libsbmlPINVOKE.new_SBaseExtensionPoint__SWIG_3(SBaseExtensionPoint.getCPtr(rhs)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates and returns a deep copy of this SBaseExtensionPoint object.
   *
   * @return the (deep) copy of this SBaseExtensionPoint object.
   */ public
 SBaseExtensionPoint clone() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBaseExtensionPoint_clone(swigCPtr);
    SBaseExtensionPoint ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBaseExtensionPoint(cPtr, true);
    return ret;
  }

  
/**
   * Returns the package name of this extension point.
   */ public
 string getPackageName() {
    string ret = libsbmlPINVOKE.SBaseExtensionPoint_getPackageName(swigCPtr);
    return ret;
  }

  
/**
   * Returns the libSBML type code of this extension point.
   */ public new
 int getTypeCode() {
    int ret = libsbmlPINVOKE.SBaseExtensionPoint_getTypeCode(swigCPtr);
    return ret;
  }

  
/**
   * the target element name
   */ public
 string getElementName() {
    string ret = libsbmlPINVOKE.SBaseExtensionPoint_getElementName(swigCPtr);
    return ret;
  }

  
/**
   * 
   */ public
 bool isElementOnly() {
    bool ret = libsbmlPINVOKE.SBaseExtensionPoint_isElementOnly(swigCPtr);
    return ret;
  }

}

}
