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

public class OFStream : OStream {
	private HandleRef swigCPtr;

	internal OFStream(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.OFStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.OFStreamUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(OFStream obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (OFStream obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~OFStream() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_OFStream(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public OFStream(string filename, bool is_append) : this(libsbmlPINVOKE.new_OFStream__SWIG_0(filename, is_append), true) {
  }

  public OFStream(string filename) : this(libsbmlPINVOKE.new_OFStream__SWIG_1(filename), true) {
  }

  public void open(string filename, bool is_append) {
    libsbmlPINVOKE.OFStream_open__SWIG_0(swigCPtr, filename, is_append);
  }

  public void open(string filename) {
    libsbmlPINVOKE.OFStream_open__SWIG_1(swigCPtr, filename);
  }

  public void close() {
    libsbmlPINVOKE.OFStream_close(swigCPtr);
  }

  public bool is_open() {
    bool ret = libsbmlPINVOKE.OFStream_is_open(swigCPtr);
    return ret;
  }

}

}
