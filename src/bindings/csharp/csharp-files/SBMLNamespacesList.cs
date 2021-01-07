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

public class SBMLNamespacesList : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SBMLNamespacesList(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SBMLNamespacesList obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SBMLNamespacesList() {
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
          libsbmlPINVOKE.delete_SBMLNamespacesList(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public SBMLNamespacesList() : this(libsbmlPINVOKE.new_SBMLNamespacesList(), true) {
  }

  public void add(SBMLNamespaces item) {
    libsbmlPINVOKE.SBMLNamespacesList_add(swigCPtr, SBMLNamespaces.getCPtr(item));
  }

  public SBMLNamespaces get(uint n) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLNamespacesList_get(swigCPtr, n);
    SBMLNamespaces ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLNamespaces(cPtr, false);
    return ret;
  }

  public void prepend(SBMLNamespaces item) {
    libsbmlPINVOKE.SBMLNamespacesList_prepend(swigCPtr, SBMLNamespaces.getCPtr(item));
  }

  public SBMLNamespaces remove(uint n) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLNamespacesList_remove(swigCPtr, n);
    SBMLNamespaces ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLNamespaces(cPtr, false);
    return ret;
  }

  public uint getSize() {
    uint ret = libsbmlPINVOKE.SBMLNamespacesList_getSize(swigCPtr);
    return ret;
  }

}

}
