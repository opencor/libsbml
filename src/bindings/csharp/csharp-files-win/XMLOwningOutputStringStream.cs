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

public class XMLOwningOutputStringStream : IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal XMLOwningOutputStringStream(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(XMLOwningOutputStringStream obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (XMLOwningOutputStringStream obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~XMLOwningOutputStringStream() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_XMLOwningOutputStringStream(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }


/** */ /* libsbml-internal */ public
 XMLOwningOutputStringStream(string encoding, bool writeXMLDecl, string programName, string programVersion) : this(libsbmlPINVOKE.new_XMLOwningOutputStringStream__SWIG_0(encoding, writeXMLDecl, programName, programVersion), true) {
  }


/** */ /* libsbml-internal */ public
 XMLOwningOutputStringStream(string encoding, bool writeXMLDecl, string programName) : this(libsbmlPINVOKE.new_XMLOwningOutputStringStream__SWIG_1(encoding, writeXMLDecl, programName), true) {
  }


/** */ /* libsbml-internal */ public
 XMLOwningOutputStringStream(string encoding, bool writeXMLDecl) : this(libsbmlPINVOKE.new_XMLOwningOutputStringStream__SWIG_2(encoding, writeXMLDecl), true) {
  }


/** */ /* libsbml-internal */ public
 XMLOwningOutputStringStream(string encoding) : this(libsbmlPINVOKE.new_XMLOwningOutputStringStream__SWIG_3(encoding), true) {
  }


/** */ /* libsbml-internal */ public
 XMLOwningOutputStringStream() : this(libsbmlPINVOKE.new_XMLOwningOutputStringStream__SWIG_4(), true) {
  }

}

}
