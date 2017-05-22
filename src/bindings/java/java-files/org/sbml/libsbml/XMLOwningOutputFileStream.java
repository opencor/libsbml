/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

public class XMLOwningOutputFileStream {
   private long swigCPtr;
   protected boolean swigCMemOwn;

   protected XMLOwningOutputFileStream(long cPtr, boolean cMemoryOwn)
   {
     swigCMemOwn = cMemoryOwn;
     swigCPtr    = cPtr;
   }

   protected static long getCPtr(XMLOwningOutputFileStream obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (XMLOwningOutputFileStream obj)
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
        libsbmlJNI.delete_XMLOwningOutputFileStream(swigCPtr);
      }
      swigCPtr = 0;
    }
  }


/** * @internal */ public
 XMLOwningOutputFileStream(String filename, String encoding, boolean writeXMLDecl, String programName, String programVersion) {
    this(libsbmlJNI.new_XMLOwningOutputFileStream__SWIG_0(libsbml.getAbsolutePath(filename), encoding, writeXMLDecl, programName, programVersion), true);
  }


/** * @internal */ public
 XMLOwningOutputFileStream(String filename, String encoding, boolean writeXMLDecl, String programName) {
    this(libsbmlJNI.new_XMLOwningOutputFileStream__SWIG_1(libsbml.getAbsolutePath(filename), encoding, writeXMLDecl, programName), true);
  }


/** * @internal */ public
 XMLOwningOutputFileStream(String filename, String encoding, boolean writeXMLDecl) {
    this(libsbmlJNI.new_XMLOwningOutputFileStream__SWIG_2(libsbml.getAbsolutePath(filename), encoding, writeXMLDecl), true);
  }


/** * @internal */ public
 XMLOwningOutputFileStream(String filename, String encoding) {
    this(libsbmlJNI.new_XMLOwningOutputFileStream__SWIG_3(libsbml.getAbsolutePath(filename), encoding), true);
  }


/** * @internal */ public
 XMLOwningOutputFileStream(String filename) {
    this(libsbmlJNI.new_XMLOwningOutputFileStream__SWIG_4(libsbml.getAbsolutePath(filename)), true);
  }

}
