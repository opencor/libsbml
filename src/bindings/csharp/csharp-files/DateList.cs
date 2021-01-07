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

public class DateList : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DateList(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DateList obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~DateList() {
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
          libsbmlPINVOKE.delete_DateList(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public DateList() : this(libsbmlPINVOKE.new_DateList(), true) {
  }

  public void add(Date item) {
    libsbmlPINVOKE.DateList_add(swigCPtr, Date.getCPtr(item));
  }

  public Date get(uint n) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.DateList_get(swigCPtr, n);
    Date ret = (cPtr == global::System.IntPtr.Zero) ? null : new Date(cPtr, false);
    return ret;
  }

  public void prepend(Date item) {
    libsbmlPINVOKE.DateList_prepend(swigCPtr, Date.getCPtr(item));
  }

  public Date remove(uint n) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.DateList_remove(swigCPtr, n);
    Date ret = (cPtr == global::System.IntPtr.Zero) ? null : new Date(cPtr, false);
    return ret;
  }

  public uint getSize() {
    uint ret = libsbmlPINVOKE.DateList_getSize(swigCPtr);
    return ret;
  }

}

}
