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
@htmlinclude pkg-marker-core.html Log of diagnostics reported during XML processing.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * The error log is a list.  The XML layer of libSBML maintains an error
 * log associated with a given XML document or data stream.  When an
 * operation results in an error, or when there is something wrong with the
 * XML content, the problem is reported as an XMLError object stored in the
 * XMLErrorLog list.  Potential problems range from low-level issues (such
 * as the inability to open a file) to XML syntax errors (such as
 * mismatched tags or other problems).
 *
 * A typical approach for using this error log is to first use
 * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif
 * to inquire how many XMLError object instances it contains, and then to
 * iterate over the list of objects one at a time using
 * getError(unsigned int n) .  Indexing in the list begins at 0.
 *
 * In normal circumstances, programs using libSBML will actually obtain an
 * SBMLErrorLog rather than an XMLErrorLog.  The former is subclassed from
 * XMLErrorLog and simply wraps commands for working with SBMLError objects
 * rather than the low-level XMLError objects.  Classes such as
 * SBMLDocument use the higher-level SBMLErrorLog.
 */

public class XMLErrorLog : IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal XMLErrorLog(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(XMLErrorLog obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (XMLErrorLog obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~XMLErrorLog() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_XMLErrorLog(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public static bool operator==(XMLErrorLog lhs, XMLErrorLog rhs)
  {
    if((Object)lhs == (Object)rhs)
    {
      return true;
    }

    if( ((Object)lhs == null) || ((Object)rhs == null) )
    {
      return false;
    }

    return (getCPtr(lhs).Handle.ToString() == getCPtr(rhs).Handle.ToString());
  }

  public static bool operator!=(XMLErrorLog lhs, XMLErrorLog rhs)
  {
    return !(lhs == rhs);
  }

  public override bool Equals(Object sb)
  {
    if ( ! (sb is XMLErrorLog) )
    {
      return false;
    }

    return this == (XMLErrorLog)sb;
  }

  public override int GetHashCode()
  {
    return swigCPtr.Handle.ToInt32();
  }


/**
   * Returns the number of errors that have been logged.
   *
   * To retrieve individual errors from the log, callers may use
   * @if clike getError() @else XMLErrorLog::getError(unsigned int n) @endif.
   *
   * @return the number of errors that have been logged.
   */ public
 long getNumErrors() { return (long)libsbmlPINVOKE.XMLErrorLog_getNumErrors(swigCPtr); }


/**
   * Returns the <i>n</i>th XMLError object in this log.
   *
   * Index @p n is counted from 0.  Callers should first inquire about the
   * number of items in the log by using the method
   * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif.
   * Attempts to use an error index number that exceeds the actual number
   * of errors in the log will result in a @c null being returned.
   *
   * @param n the index number of the error to retrieve (with 0 being the
   * first error).
   *
   * @return the <i>n</i>th XMLError in this log, or @c null if @p n is
   * greater than or equal to
   * @if java XMLErrorLog::getNumErrors()@else getNumErrors()@endif.
   *
   * @see getNumErrors()
   */ public
 XMLError getError(long n) {
    IntPtr cPtr = libsbmlPINVOKE.XMLErrorLog_getError(swigCPtr, n);
    XMLError ret = (cPtr == IntPtr.Zero) ? null : new XMLError(cPtr, false);
    return ret;
  }


/**
   * Deletes all errors from this log.
   */ public
 void clearLog() {
    libsbmlPINVOKE.XMLErrorLog_clearLog(swigCPtr);
  }


/** */ /* libsbml-internal */ public
 XMLErrorLog() : this(libsbmlPINVOKE.new_XMLErrorLog__SWIG_0(), true) {
  }


/** */ /* libsbml-internal */ public
 XMLErrorLog(XMLErrorLog other) : this(libsbmlPINVOKE.new_XMLErrorLog__SWIG_1(XMLErrorLog.getCPtr(other)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void add(XMLError error) {
    libsbmlPINVOKE.XMLErrorLog_add__SWIG_0(swigCPtr, XMLError.getCPtr(error));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 void add(SWIGTYPE_p_std__vectorT_XMLError_p_t errors) {
    libsbmlPINVOKE.XMLErrorLog_add__SWIG_1(swigCPtr, SWIGTYPE_p_std__vectorT_XMLError_p_t.getCPtr(errors));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes all errors contained in this log to a string and returns it.
   *
   * This method uses printErrors() to format the diagnostic messages.
   * Please consult that method for information about the organization
   * of the messages in the string returned by this method.
   *
   * @return a string containing all logged errors and warnings.
   *
   * @see printErrors()
   */ public
 string toString() {
    string ret = libsbmlPINVOKE.XMLErrorLog_toString(swigCPtr);
    return ret;
  }


/**
   * Prints all the errors or warnings stored in this error log.
   *
   * This method prints the text to the stream given by the optional
   * parameter @p stream.  If no stream is given, the method prints the
   * output to the standard error stream.
   *
   * The format of the output is:
   * @verbatim
   N error(s):
     line NNN: (id) message
 @endverbatim
   * If no errors have occurred, i.e.,
   * <code>getNumErrors() == 0</code>, then no output will be produced.

   * @param stream the ostream or ostringstream object indicating where
   * the output should be printed.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void printErrors(OStream stream) {
    libsbmlPINVOKE.XMLErrorLog_printErrors__SWIG_0(swigCPtr, SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Prints all the errors or warnings stored in this error log.
   *
   * This method prints the text to the stream given by the optional
   * parameter @p stream.  If no stream is given, the method prints the
   * output to the standard error stream.
   *
   * The format of the output is:
   * @verbatim
   N error(s):
     line NNN: (id) message
 @endverbatim
   * If no errors have occurred, i.e.,
   * <code>getNumErrors() == 0</code>, then no output will be produced.

   * @param stream the ostream or ostringstream object indicating where
   * the output should be printed.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void printErrors() {
    libsbmlPINVOKE.XMLErrorLog_printErrors__SWIG_1(swigCPtr);
  }


/**
   * Prints the errors or warnings with given severity stored in this error log.
   *
   * This method prints the text to the stream given by the optional
   * parameter @p stream.  If no stream is given, the method prints the
   * output to the standard error stream.
   *
   * The format of the output is:
   * @verbatim
   N error(s):
     line NNN: (id) message
@endverbatim
   * If no errors with that severity was found, then no output will be produced.
   *
   * @param stream the ostream or ostringstream object indicating where
   * the output should be printed.
   * @param severity the severity of the errors sought.
   *
   */ public
 void printErrors(OStream stream, long severity) {
    libsbmlPINVOKE.XMLErrorLog_printErrors__SWIG_2(swigCPtr, SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()), severity);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Returns a boolean indicating whether or not the severity has been
   * overridden.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @return @c true if an error severity override has been set, @c false
   * otherwise.
   *
   * @see getSeverityOverride()
   * @see setSeverityOverride(@if java int@endif)
   * @see unsetSeverityOverride()
   * @see changeErrorSeverity(@if java int, int, String@endif)
   */ public
 bool isSeverityOverridden() {
    bool ret = libsbmlPINVOKE.XMLErrorLog_isSeverityOverridden(swigCPtr);
    return ret;
  }


/**
   * Usets an existing override.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @see getSeverityOverride()
   * @see setSeverityOverride(@if java int@endif)
   * @see isSeverityOverridden()
   * @see changeErrorSeverity(@if java int, int, String@endif)
   */ public
 void unsetSeverityOverride() {
    libsbmlPINVOKE.XMLErrorLog_unsetSeverityOverride(swigCPtr);
  }


/**
   * Returns the current override.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @return a severity override code.  The possible values are drawn
   * from @if clike the enumeration #XMLErrorSeverityOverride_t@else the
   * set of integer constants whose names begin with the prefix
   * <code>LIBSBML_OVERRIDE_</code>@endif:
   * @li @link libsbml#LIBSBML_OVERRIDE_DISABLED LIBSBML_OVERRIDE_DISABLED@endlink
   * @li @link libsbml#LIBSBML_OVERRIDE_DONT_LOG LIBSBML_OVERRIDE_DONT_LOG@endlink
   * @li @link libsbml#LIBSBML_OVERRIDE_WARNING LIBSBML_OVERRIDE_WARNING@endlink
   *
   * @see isSeverityOverridden()
   * @see setSeverityOverride(@if java int@endif)
   * @see unsetSeverityOverride()
   * @see changeErrorSeverity(@if java int, int, String@endif)
   */ public
 int getSeverityOverride() {
    int ret = libsbmlPINVOKE.XMLErrorLog_getSeverityOverride(swigCPtr);
    return ret;
  }


/**
   * Set the severity override.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @param severity an override code indicating what to do.  If the value is
   * @link libsbml#LIBSBML_OVERRIDE_DISABLED LIBSBML_OVERRIDE_DISABLED@endlink
   * (the default setting) all errors logged will be given the severity
   * specified in their usual definition.   If the value is
   * @link libsbml#LIBSBML_OVERRIDE_WARNING LIBSBML_OVERRIDE_WARNING@endlink,
   * then all errors will be logged as warnings.  If the value is
   * @link libsbml#LIBSBML_OVERRIDE_DONT_LOG LIBSBML_OVERRIDE_DONT_LOG@endlink,
   * no error will be logged, regardless of their severity.
   *
   * @see isSeverityOverridden()
   * @see getSeverityOverride()
   * @see unsetSeverityOverride()
   * @see changeErrorSeverity(@if java int, int, String@endif)
   */ public
 void setSeverityOverride(int severity) {
    libsbmlPINVOKE.XMLErrorLog_setSeverityOverride(swigCPtr, severity);
  }


/**
   * Changes the severity override for errors in the log that have a given
   * severity.
   *
   * This method searches through the list of errors in the log, comparing
   * each one's severity to the value of @p originalSeverity.  For each error
   * encountered with that severity logged by the named @p package, the
   * severity of the error is reset to @p targetSeverity.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @param originalSeverity the severity code to match.
   *
   * @param targetSeverity the severity code to use as the new severity.
   *
   * @param package a string, the name of an SBML Level&nbsp;3 package
   * extension to use to narrow the search for errors.  A value of @c 'all'
   * signifies to match against errors logged from any package; a value of a
   * package nickname such as @c 'comp' signifies to limit consideration to
   * errors from just that package.  If no value is provided, @c 'all' is the
   * default.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   *
   * @see isSeverityOverridden()
   * @see getSeverityOverride()
   * @see setSeverityOverride(@if java int@endif)
   * @see unsetSeverityOverride()
   */ public
 void changeErrorSeverity(int originalSeverity, int targetSeverity, string package) {
    libsbmlPINVOKE.XMLErrorLog_changeErrorSeverity__SWIG_0(swigCPtr, originalSeverity, targetSeverity, package);
  }


/**
   * Changes the severity override for errors in the log that have a given
   * severity.
   *
   * This method searches through the list of errors in the log, comparing
   * each one's severity to the value of @p originalSeverity.  For each error
   * encountered with that severity logged by the named @p package, the
   * severity of the error is reset to @p targetSeverity.
   *
   *
 *
 * The <em>severity override</em> mechanism in XMLErrorLog is intended to help
 * applications handle error conditions in ways that may be more convenient
 * for those applications.  It is possible to use the mechanism to override
 * the severity code of errors logged by libSBML, and even to disable error
 * logging completely.  An override stays in effect until the override is
 * changed again by the calling application.
   *
   * @param originalSeverity the severity code to match.
   *
   * @param targetSeverity the severity code to use as the new severity.
   *
   * @param package a string, the name of an SBML Level&nbsp;3 package
   * extension to use to narrow the search for errors.  A value of @c 'all'
   * signifies to match against errors logged from any package; a value of a
   * package nickname such as @c 'comp' signifies to limit consideration to
   * errors from just that package.  If no value is provided, @c 'all' is the
   * default.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   *
   * @see isSeverityOverridden()
   * @see getSeverityOverride()
   * @see setSeverityOverride(@if java int@endif)
   * @see unsetSeverityOverride()
   */ public
 void changeErrorSeverity(int originalSeverity, int targetSeverity) {
    libsbmlPINVOKE.XMLErrorLog_changeErrorSeverity__SWIG_1(swigCPtr, originalSeverity, targetSeverity);
  }


/**
  * Returns @c true if XMLErrorLog contains an errorId
  *
  * @param errorId the error identifier of the error to be found.
  */ public
 bool contains(long errorId) {
    bool ret = libsbmlPINVOKE.XMLErrorLog_contains(swigCPtr, errorId);
    return ret;
  }

}

}
