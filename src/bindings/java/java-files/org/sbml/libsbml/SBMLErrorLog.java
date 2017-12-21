/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  Log of diagnostics reported during processing.
 <p>
 * <p style='color: #777; font-style: italic'>
This class of objects is defined by libSBML only and has no direct
equivalent in terms of SBML components.  This class is not prescribed by
the SBML specifications, although it is used to implement features
defined in SBML.
</p>

 <p>
 * The error log is a list.  Each {@link SBMLDocument} maintains its own
 * {@link SBMLErrorLog}.  When a libSBML operation on SBML content results in an
 * error, or when there is something worth noting about the SBML content,
 * the issue is reported as an {@link SBMLError} object stored in the {@link SBMLErrorLog}
 * list.
 <p>
 * {@link SBMLErrorLog} is derived from {@link XMLErrorLog}, an object class that serves
 * exactly the same purpose but for the XML parsing layer.  {@link XMLErrorLog}
 * provides crucial methods such as
 * {@link XMLErrorLog#getNumErrors()}
 * for determining how many {@link SBMLError} or {@link XMLError} objects are in the log.
 * {@link SBMLErrorLog} inherits these methods.
 <p>
 * The general approach to working with {@link SBMLErrorLog} in user programs
 * involves first obtaining a pointer to a log from a libSBML object such
 * as {@link SBMLDocument}.  Callers should then use
 * {@link XMLErrorLog#getNumErrors()} to inquire how
 * many objects there are in the list.  (The answer may be 0.)  If there is
 * at least one {@link SBMLError} object in the {@link SBMLErrorLog} instance, callers can
 * then iterate over the list using
 * {@link SBMLErrorLog#getError(long n)}@if clike @endif,
 * using methods provided by the {@link SBMLError} class to find out the error code
 * and associated information such as the error severity, the message, and
 * the line number in the input.
 <p>
 * If you wish to simply print the error strings for a human to read, an
 * easier and more direct way might be to use {@link SBMLDocument#printErrors()}.
 <p>
 * @see SBMLError
 * @see XMLErrorLog
 * @see XMLError
 */

public class SBMLErrorLog extends XMLErrorLog {
   private long swigCPtr;

   protected SBMLErrorLog(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.SBMLErrorLog_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(SBMLErrorLog obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (SBMLErrorLog obj)
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
        libsbmlJNI.delete_SBMLErrorLog(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }


/**
   * Returns the <i>n</i>th {@link SBMLError} object in this log.
   <p>
   * Index <code>n</code> is counted from 0.  Callers should first inquire about the
   * number of items in the log by using the
   * {@link XMLErrorLog#getNumErrors()} method.
   * Attempts to use an error index number that exceeds the actual number
   * of errors in the log will result in a <code>null</code> being returned.
   <p>
   * @param n the index number of the error to retrieve (with 0 being the
   * first error).
   <p>
   * @return the <i>n</i>th {@link SBMLError} in this log, or <code>null</code> if <code>n</code> is
   * greater than or equal to
   * {@link XMLErrorLog#getNumErrors()}.
   <p>
   * @see #getNumErrors()
   */ public
 SBMLError getError(long n) {
    long cPtr = libsbmlJNI.SBMLErrorLog_getError(swigCPtr, this, n);
    return (cPtr == 0) ? null : new SBMLError(cPtr, false);
  }


/**
   * Returns the <i>n</i>th {@link SBMLError} object with given severity in this log.
   <p>
   * Index <code>n</code> is counted from 0.  Callers should first inquire about the
   * number of items in the log by using the
   * {@link SBMLErrorLog#getNumFailsWithSeverity(long severity)} method.
   * Attempts to use an error index number that exceeds the actual number
   * of errors in the log will result in a <code>null</code> being returned.
   <p>
   * @param n the index number of the error to retrieve (with 0 being the
   * first error).
   * @param severity the severity of the error to retrieve.
   <p>
   * @return the <i>n</i>th {@link SBMLError} in this log, or <code>null</code> if <code>n</code> is
   * greater than or equal to
   * {@link SBMLErrorLog#getNumFailsWithSeverity(long severity)}.
   <p>
   * @see #getNumFailsWithSeverity(long severity)
   */ public
 SBMLError getErrorWithSeverity(long n, long severity) {
    long cPtr = libsbmlJNI.SBMLErrorLog_getErrorWithSeverity(swigCPtr, this, n, severity);
    return (cPtr == 0) ? null : new SBMLError(cPtr, false);
  }


/**
   * Returns the number of errors that have been logged with the given
   * severity code.
   <p>
   * <p>
 * LibSBML associates severity levels with every {@link SBMLError} object to
 * provide an indication of how serious the problem is.  Severities range
 * from informational diagnostics to fatal (irrecoverable) errors.  Given
 * an {@link SBMLError} object instance, a caller can interrogate it for its
 * severity level using methods such as {@link SBMLError#getSeverity()},
 * {@link SBMLError#isFatal()}, and so on.  The present method encapsulates
 * iteration and interrogation of all objects in an {@link SBMLErrorLog}, making
 * it easy to check for the presence of error objects with specific
 * severity levels.
   <p>
   * @param severity a
   * value from the set of <code>LIBSBML_SEV_</code> constants defined by
   * the interface class <code><a
   * href='libsbmlConstants.html'>libsbmlConstants</a></code>
   <p>
   * @return a count of the number of errors with the given severity code.
   <p>
   * @see #getNumErrors()
   */ public
 long getNumFailsWithSeverity(long severity) {
    return libsbmlJNI.SBMLErrorLog_getNumFailsWithSeverity__SWIG_0(swigCPtr, this, severity);
  }


/** * @internal */ public
 SBMLErrorLog() {
    this(libsbmlJNI.new_SBMLErrorLog__SWIG_0(), true);
  }


/** * @internal */ public
 SBMLErrorLog(SBMLErrorLog orig) {
    this(libsbmlJNI.new_SBMLErrorLog__SWIG_1(SBMLErrorLog.getCPtr(orig), orig), true);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version, String details, long line, long column, long severity, long category) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_0(swigCPtr, this, errorId, level, version, details, line, column, severity, category);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version, String details, long line, long column, long severity) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_1(swigCPtr, this, errorId, level, version, details, line, column, severity);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version, String details, long line, long column) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_2(swigCPtr, this, errorId, level, version, details, line, column);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version, String details, long line) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_3(swigCPtr, this, errorId, level, version, details, line);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version, String details) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_4(swigCPtr, this, errorId, level, version, details);
  }


/** * @internal */ public
 void logError(long errorId, long level, long version) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_5(swigCPtr, this, errorId, level, version);
  }


/** * @internal */ public
 void logError(long errorId, long level) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_6(swigCPtr, this, errorId, level);
  }


/** * @internal */ public
 void logError(long errorId) {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_7(swigCPtr, this, errorId);
  }


/** * @internal */ public
 void logError() {
    libsbmlJNI.SBMLErrorLog_logError__SWIG_8(swigCPtr, this);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version, String details, long line, long column, long severity, long category) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_0(swigCPtr, this, arg0, errorId, pkgVersion, level, version, details, line, column, severity, category);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version, String details, long line, long column, long severity) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_1(swigCPtr, this, arg0, errorId, pkgVersion, level, version, details, line, column, severity);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version, String details, long line, long column) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_2(swigCPtr, this, arg0, errorId, pkgVersion, level, version, details, line, column);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version, String details, long line) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_3(swigCPtr, this, arg0, errorId, pkgVersion, level, version, details, line);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version, String details) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_4(swigCPtr, this, arg0, errorId, pkgVersion, level, version, details);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level, long version) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_5(swigCPtr, this, arg0, errorId, pkgVersion, level, version);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion, long level) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_6(swigCPtr, this, arg0, errorId, pkgVersion, level);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId, long pkgVersion) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_7(swigCPtr, this, arg0, errorId, pkgVersion);
  }


/** * @internal */ public
 void logPackageError(String arg0, long errorId) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_8(swigCPtr, this, arg0, errorId);
  }


/** * @internal */ public
 void logPackageError(String arg0) {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_9(swigCPtr, this, arg0);
  }


/** * @internal */ public
 void logPackageError() {
    libsbmlJNI.SBMLErrorLog_logPackageError__SWIG_10(swigCPtr, this);
  }


/** * @internal */ public
 void add(SBMLError error) {
    libsbmlJNI.SBMLErrorLog_add(swigCPtr, this, SBMLError.getCPtr(error), error);
  }


/**
   * Removes an error having errorId from the {@link SBMLError} list.
   <p>
   * Only the first item will be removed if there are multiple errors
   * with the given errorId.
   <p>
   * @param errorId the error identifier of the error to be removed.
   */ public
 void remove(long errorId) {
    libsbmlJNI.SBMLErrorLog_remove(swigCPtr, this, errorId);
  }


/**
   * Removes all errors having errorId from the {@link SBMLError} list.
   <p>
   * @param errorId the error identifier of the error to be removed.
   */ public
 void removeAll(long errorId) {
    libsbmlJNI.SBMLErrorLog_removeAll(swigCPtr, this, errorId);
  }


/**
   * Returns <code>true</code> if {@link SBMLErrorLog} contains an errorId
   <p>
   * @param errorId the error identifier of the error to be found.
   */ public
 boolean contains(long errorId) {
    return libsbmlJNI.SBMLErrorLog_contains(swigCPtr, this, errorId);
  }

}
