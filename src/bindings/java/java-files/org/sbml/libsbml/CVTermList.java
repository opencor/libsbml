/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 4.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

public class CVTermList {
  private transient long swigCPtr;
  protected transient boolean swigCMemOwn;

  protected CVTermList(long cPtr, boolean cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  protected static long getCPtr(CVTermList obj) {
    return (obj == null) ? 0 : obj.swigCPtr;
  }

  @SuppressWarnings("deprecation")
  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        libsbmlJNI.delete_CVTermList(swigCPtr);
      }
      swigCPtr = 0;
    }
  }

  public CVTermList() {
    this(libsbmlJNI.new_CVTermList(), true);
  }

  public void add(CVTerm item) {
    libsbmlJNI.CVTermList_add(swigCPtr, this, CVTerm.getCPtr(item), item);
  }

  public CVTerm get(long n) {
    long cPtr = libsbmlJNI.CVTermList_get(swigCPtr, this, n);
    return (cPtr == 0) ? null : new CVTerm(cPtr, false);
  }

  public void prepend(CVTerm item) {
    libsbmlJNI.CVTermList_prepend(swigCPtr, this, CVTerm.getCPtr(item), item);
  }

  public CVTerm remove(long n) {
    long cPtr = libsbmlJNI.CVTermList_remove(swigCPtr, this, n);
    return (cPtr == 0) ? null : new CVTerm(cPtr, false);
  }

  public long getSize() {
    return libsbmlJNI.CVTermList_getSize(swigCPtr, this);
  }

}
