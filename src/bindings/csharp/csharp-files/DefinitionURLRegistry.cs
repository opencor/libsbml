using System;
using System.Runtime.InteropServices;
 
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace libsbmlcs {

 using System;
 using System.Runtime.InteropServices;

/** 
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html Registry of all libSBML SBML DefinitionURLs.
 *
 * @htmlinclude libsbml-facility-only-warning.html
 *
 * LibSBML provides facilities for transforming and converting SBML
 * documents in various ways.  These transformations can involve
 * essentially anything that can be written algorithmically; examples
 * include converting the units of measurement in a model, or converting
 * from one Level+Version combination of SBML to another.  DefinitionURLs are
 * implemented as objects derived from the class DefinitionURL.
 *
 * The DefinitionURL registry, implemented as a singleton object of class
 * DefinitionURLRegistry, maintains a list of known DefinitionURLs and provides
 * methods for discovering them.  Callers can use the method
 * DefinitionURLRegistry::getNumDefinitionURLs() to find out how many
 * DefinitionURLs are registered, then use
 * DefinitionURLRegistry::getDefinitionURLByIndex(@if java int@endif) to
 * iterate over each one; alternatively, callers can use
 * DefinitionURLRegistry::getDefinitionURLFor(@if java ConversionProperties@endif)
 * to search for a DefinitionURL having specific properties.
 */

public class DefinitionURLRegistry : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;
	
	internal DefinitionURLRegistry(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}
	
	internal static HandleRef getCPtr(DefinitionURLRegistry obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}
	
	internal static HandleRef getCPtrAndDisown (DefinitionURLRegistry obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);
		
		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}
		
		return ptr;
	}

  ~DefinitionURLRegistry() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_DefinitionURLRegistry(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  
/**
   * Returns the singleton instance for the DefinitionURL registry.
   *
   * Prior to using the registry, callers have to obtain a copy of the
   * registry.  This static method provides the means for doing that.
   *
   * @return the singleton for the DefinitionURL registry.
   */ public
 static DefinitionURLRegistry getInstance() {
    DefinitionURLRegistry ret = new DefinitionURLRegistry(libsbmlPINVOKE.DefinitionURLRegistry_getInstance(), false);
    return ret;
  }

  
/**
   * Adds the given DefinitionURL to the registry of SBML DefinitionURLs.
   *
   * @param url the DefinitionURL to add to the registry.
   * @param type the ASTNodeType_t of the URL to add to the registry.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 static int addDefinitionURL(string url, int type) {
    int ret = libsbmlPINVOKE.DefinitionURLRegistry_addDefinitionURL(url, type);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  
/**
   * Returns the number of DefinitionURLs known by the registry.
   *
   * @return the number of registered DefinitionURLs.
   *
   * @see getDefinitionURLByIndex(@if java int@endif)
   */ public
 static int getNumDefinitionURLs() {
    int ret = libsbmlPINVOKE.DefinitionURLRegistry_getNumDefinitionURLs();
    return ret;
  }

  
/** */ public
 static void addSBMLDefinitions() {
    libsbmlPINVOKE.DefinitionURLRegistry_addSBMLDefinitions();
  }

  
/** */ public
 static bool getCoreDefinitionsAdded() {
    bool ret = libsbmlPINVOKE.DefinitionURLRegistry_getCoreDefinitionsAdded();
    return ret;
  }

  
/** */ public
 static int getType(string url) {
    int ret = libsbmlPINVOKE.DefinitionURLRegistry_getType(url);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  
/** */ public
 static string getDefinitionUrlByIndex(int index) {
    string ret = libsbmlPINVOKE.DefinitionURLRegistry_getDefinitionUrlByIndex(index);
    return ret;
  }

  
/** */ public
 static void clearDefinitions() {
    libsbmlPINVOKE.DefinitionURLRegistry_clearDefinitions();
  }

}

}
