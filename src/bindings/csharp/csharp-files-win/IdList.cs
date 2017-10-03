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
@htmlinclude pkg-marker-core.html Maintains a list of SIds.
 * @internal
 */

public class IdList : IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal IdList(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(IdList obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (IdList obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~IdList() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_IdList(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public IdList() : this(libsbmlPINVOKE.new_IdList__SWIG_0(), true) {
  }

  public IdList(string commaSeparated) : this(libsbmlPINVOKE.new_IdList__SWIG_1(commaSeparated), true) {
  }


/** */ /* libsbml-internal */ public
 void append(string id) {
    libsbmlPINVOKE.IdList_append(swigCPtr, id);
  }


/** */ /* libsbml-internal */ public
 bool contains(string id) {
    bool ret = libsbmlPINVOKE.IdList_contains(swigCPtr, id);
    return ret;
  }


/** */ /* libsbml-internal */ public
 void removeIdsBefore(string id) {
    libsbmlPINVOKE.IdList_removeIdsBefore(swigCPtr, id);
  }


/** */ /* libsbml-internal */ public
 long size() { return (long)libsbmlPINVOKE.IdList_size(swigCPtr); }

  public void clear() {
    libsbmlPINVOKE.IdList_clear(swigCPtr);
  }

  public string at(int n) {
    string ret = libsbmlPINVOKE.IdList_at(swigCPtr, n);
    return ret;
  }

}

}