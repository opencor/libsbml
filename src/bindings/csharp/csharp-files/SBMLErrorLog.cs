using System;
using System.Runtime.InteropServices;

//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
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
@htmlinclude pkg-marker-core.html Log of diagnostics reported during processing.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * The error log is a list.  Each SBMLDocument maintains its own
 * SBMLErrorLog.  When a libSBML operation on SBML content results in an
 * error, or when there is something worth noting about the SBML content,
 * the issue is reported as an SBMLError object stored in the SBMLErrorLog
 * list.
 *
 * SBMLErrorLog is derived from XMLErrorLog, an object class that serves
 * exactly the same purpose but for the XML parsing layer.  XMLErrorLog
 * provides crucial methods such as
 * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif
 * for determining how many SBMLError or XMLError objects are in the log.
 * SBMLErrorLog inherits these methods.
 *
 * The general approach to working with SBMLErrorLog in user programs
 * involves first obtaining a pointer to a log from a libSBML object such
 * as SBMLDocument.  Callers should then use
 * @if java XMLErrorLog::getNumErrors()@else getNumErrors() @endif to inquire how
 * many objects there are in the list.  (The answer may be 0.)  If there is
 * at least one SBMLError object in the SBMLErrorLog instance, callers can
 * then iterate over the list using
 * SBMLErrorLog::getError(@if java long n@endif)@if clike @endif,
 * using methods provided by the SBMLError class to find out the error code
 * and associated information such as the error severity, the message, and
 * the line number in the input.
 *
 * If you wish to simply print the error strings for a human to read, an
 * easier and more direct way might be to use SBMLDocument::printErrors().
 *
 * @see SBMLError
 * @see XMLErrorLog
 * @see XMLError
 */

public class SBMLErrorLog : XMLErrorLog {
	private HandleRef swigCPtr;

	internal SBMLErrorLog(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.SBMLErrorLog_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.SBMLErrorLogUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SBMLErrorLog obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (SBMLErrorLog obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~SBMLErrorLog() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLErrorLog(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


/**
   * Returns the <i>n</i>th SBMLError object in this log.
   *
   * Index @p n is counted from 0.  Callers should first inquire about the
   * number of items in the log by using the
   * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif method.
   * Attempts to use an error index number that exceeds the actual number
   * of errors in the log will result in a @c null being returned.
   *
   * @param n the index number of the error to retrieve (with 0 being the
   * first error).
   *
   * @return the <i>n</i>th SBMLError in this log, or @c null if @p n is
   * greater than or equal to
   * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif.
   *
   * @see getNumErrors()
   */ public new
 SBMLError getError(long n) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLErrorLog_getError(swigCPtr, n);
    SBMLError ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLError(cPtr, false);
    return ret;
  }


/**
   * Returns the <i>n</i>th SBMLError object with given severity in this log.
   *
   * Index @p n is counted from 0.  Callers should first inquire about the
   * number of items in the log by using the
   * @if java SBMLErrorLog::getNumFailsWithSeverity(long severity)@else getNumFailsWithSeverity()@endif method.
   * Attempts to use an error index number that exceeds the actual number
   * of errors in the log will result in a @c null being returned.
   *
   * @param n the index number of the error to retrieve (with 0 being the
   * first error).
   * @param severity the severity of the error to retrieve.
   *
   * @return the <i>n</i>th SBMLError in this log, or @c null if @p n is
   * greater than or equal to
   * @if java SBMLErrorLog::getNumFailsWithSeverity(long severity)@else getNumFailsWithSeverity()@endif.
   *
   * @see getNumFailsWithSeverity(unsigned int severity)
   */ public
 SBMLError getErrorWithSeverity(long n, long severity) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLErrorLog_getErrorWithSeverity(swigCPtr, n, severity);
    SBMLError ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLError(cPtr, false);
    return ret;
  }


/**
   * Returns the number of errors that have been logged with the given
   * severity code.
   *
   *
 *
 * LibSBML associates severity levels with every SBMLError object to
 * provide an indication of how serious the problem is.  Severities range
 * from informational diagnostics to fatal (irrecoverable) errors.  Given
 * an SBMLError object instance, a caller can interrogate it for its
 * severity level using methods such as SBMLError::getSeverity(),
 * SBMLError::isFatal(), and so on.  The present method encapsulates
 * iteration and interrogation of all objects in an SBMLErrorLog, making
 * it easy to check for the presence of error objects with specific
 * severity levels.
 *
   *
   * @if clike @param severity a value from
   * #SBMLErrorSeverity_t @endif@if java @param severity a
   * value from the set of <code>LIBSBML_SEV_</code> constants defined by
   * the interface class <code><a
   * href='libsbml.libsbml.html'>libsbmlConstants</a></code> @endif@if python @param severity a
   * value from the set of <code>LIBSBML_SEV_</code> constants defined by
   * the interface class @link libsbml libsbml@endlink. @endif
   *
   * @return a count of the number of errors with the given severity code.
   *
   * @see getNumErrors()
   */ public
 long getNumFailsWithSeverity(long severity) { return (long)libsbmlPINVOKE.SBMLErrorLog_getNumFailsWithSeverity__SWIG_0(swigCPtr, severity); }


/** */ /* libsbml-internal */ public
 SBMLErrorLog() : this(libsbmlPINVOKE.new_SBMLErrorLog__SWIG_0(), true) {
  }


/** */ /* libsbml-internal */ public
 SBMLErrorLog(SBMLErrorLog orig) : this(libsbmlPINVOKE.new_SBMLErrorLog__SWIG_1(SBMLErrorLog.getCPtr(orig)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version, string details, long line, long column, long severity, long category) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_0(swigCPtr, errorId, level, version, details, line, column, severity, category);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version, string details, long line, long column, long severity) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_1(swigCPtr, errorId, level, version, details, line, column, severity);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version, string details, long line, long column) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_2(swigCPtr, errorId, level, version, details, line, column);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version, string details, long line) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_3(swigCPtr, errorId, level, version, details, line);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version, string details) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_4(swigCPtr, errorId, level, version, details);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level, long version) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_5(swigCPtr, errorId, level, version);
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId, long level) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_6(swigCPtr, errorId, level);
  }


/** */ /* libsbml-internal */ public
 void logError(long errorId) {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_7(swigCPtr, errorId);
  }


/** */ /* libsbml-internal */ public
 void logError() {
    libsbmlPINVOKE.SBMLErrorLog_logError__SWIG_8(swigCPtr);
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version, string details, long line, long column, long severity, long category) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_0(swigCPtr, package, errorId, pkgVersion, level, version, details, line, column, severity, category);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version, string details, long line, long column, long severity) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_1(swigCPtr, package, errorId, pkgVersion, level, version, details, line, column, severity);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version, string details, long line, long column) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_2(swigCPtr, package, errorId, pkgVersion, level, version, details, line, column);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version, string details, long line) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_3(swigCPtr, package, errorId, pkgVersion, level, version, details, line);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version, string details) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_4(swigCPtr, package, errorId, pkgVersion, level, version, details);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level, long version) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_5(swigCPtr, package, errorId, pkgVersion, level, version);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion, long level) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_6(swigCPtr, package, errorId, pkgVersion, level);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId, long pkgVersion) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_7(swigCPtr, package, errorId, pkgVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package, long errorId) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_8(swigCPtr, package, errorId);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError(string package) {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_9(swigCPtr, package);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void logPackageError() {
    libsbmlPINVOKE.SBMLErrorLog_logPackageError__SWIG_10(swigCPtr);
  }


/** */ /* libsbml-internal */ public
 void add(SBMLError error) {
    libsbmlPINVOKE.SBMLErrorLog_add(swigCPtr, SBMLError.getCPtr(error));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Removes an error having errorId from the SBMLError list.
   *
   * Only the first item will be removed if there are multiple errors
   * with the given errorId.
   *
   * @param errorId the error identifier of the error to be removed.
   */ public
 void remove(long errorId) {
    libsbmlPINVOKE.SBMLErrorLog_remove(swigCPtr, errorId);
  }


/**
   * Removes all errors having errorId from the SBMLError list.
   *
   * @param errorId the error identifier of the error to be removed.
   */ public
 void removeAll(long errorId) {
    libsbmlPINVOKE.SBMLErrorLog_removeAll(swigCPtr, errorId);
  }


/**
   * Returns @c true if SBMLErrorLog contains an errorId
   *
   * @param errorId the error identifier of the error to be found.
   */ public
 bool contains(long errorId) {
    bool ret = libsbmlPINVOKE.SBMLErrorLog_contains(swigCPtr, errorId);
    return ret;
  }

}

}
