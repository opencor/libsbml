/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  Base class for filter functions.
 <p>
 * <p style='color: #777; font-style: italic'>
This class of objects is defined by libSBML only and has no direct
equivalent in terms of SBML components.  It is a class used in
the implementation of extra functionality provided by libSBML.
</p>

 <p>
 * Some libSBML objects provide the ability to return lists of components.
 * To provide callers with greater control over exactly what is
 * returned, these methods take optional arguments in the form of filters.
 * The {@link ElementFilter} class is the parent class for these filters.
 */

public class ElementFilter {
   private long swigCPtr;
   protected boolean swigCMemOwn;

   protected ElementFilter(long cPtr, boolean cMemoryOwn)
   {
     swigCMemOwn = cMemoryOwn;
     swigCPtr    = cPtr;
   }

   protected static long getCPtr(ElementFilter obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (ElementFilter obj)
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
        libsbmlJNI.delete_ElementFilter(swigCPtr);
      }
      swigCPtr = 0;
    }
  }

  protected void swigDirectorDisconnect() {
    swigCMemOwn = false;
    delete();
  }

  public void swigReleaseOwnership() {
    swigCMemOwn = false;
    libsbmlJNI.ElementFilter_change_ownership(this, swigCPtr, false);
  }

  public void swigTakeOwnership() {
    swigCMemOwn = true;
    libsbmlJNI.ElementFilter_change_ownership(this, swigCPtr, true);
  }


/**
   * Creates a new {@link ElementFilter} object.
   */ public
 ElementFilter() {
    this(libsbmlJNI.new_ElementFilter(), true);
    libsbmlJNI.ElementFilter_director_connect(this, swigCPtr, swigCMemOwn, true);
  }


/**
   * Predicate to test elements.
   <p>
   * This is the central predicate of the {@link ElementFilter} class.  In subclasses
   * of {@link ElementFilter}, callers should implement this method such that it
   * returns <code>true</code> for <code>element</code> arguments that are 'desirable' and
   * <code>false</code> for those that are 'undesirable' in whatever filtering context the
   * {@link ElementFilter} subclass is designed to be used.
   <p>
   * @param element the element to be tested.
   <p>
   * @return <code>true</code> if the <code>element</code> is desirable or should be kept,
   * <code>false</code> otherwise.
   */ public
 boolean filter(SBase element) {
    return (getClass() == ElementFilter.class) ? libsbmlJNI.ElementFilter_filter(swigCPtr, this, SBase.getCPtr(element), element) : libsbmlJNI.ElementFilter_filterSwigExplicitElementFilter(swigCPtr, this, SBase.getCPtr(element), element);
  }

}
