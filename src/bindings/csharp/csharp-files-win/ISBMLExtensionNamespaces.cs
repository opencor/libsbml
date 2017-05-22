/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace libsbml {

 using System;
 using System.Runtime.InteropServices;

/**
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html
 *
 * @htmlinclude not-sbml-warning.html
 * @internal
 */

public class ISBMLExtensionNamespaces : SBMLNamespaces {
	private HandleRef swigCPtr;

	internal ISBMLExtensionNamespaces(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.ISBMLExtensionNamespaces_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.ISBMLExtensionNamespacesUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(ISBMLExtensionNamespaces obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (ISBMLExtensionNamespaces obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~ISBMLExtensionNamespaces() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_ISBMLExtensionNamespaces(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


/**
   * Returns a string representing the SBML XML namespace of this
   * object.
   *
   * @return a string representing the SBML namespace that reflects the
   * SBML Level and Version of this object.
   */ public new
 string getURI() {
    string ret = libsbmlPINVOKE.ISBMLExtensionNamespaces_getURI(swigCPtr);
    return ret;
  }

  public virtual long getPackageVersion() { return (long)libsbmlPINVOKE.ISBMLExtensionNamespaces_getPackageVersion(swigCPtr); }


/**
   * Returns the name of the main package for this namespace.
   *
   * @return the name of the main package for this namespace.
   * 'core' will be returned if this namespace is defined in the SBML
   * core.
   */ public new
 string getPackageName() {
    string ret = libsbmlPINVOKE.ISBMLExtensionNamespaces_getPackageName(swigCPtr);
    return ret;
  }

  public virtual void setPackageVersion(long pkgVersion) {
    libsbmlPINVOKE.ISBMLExtensionNamespaces_setPackageVersion(swigCPtr, pkgVersion);
  }

}

}
