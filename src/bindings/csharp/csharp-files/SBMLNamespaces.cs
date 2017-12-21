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
@htmlinclude pkg-marker-core.html Set of SBML Level + Version + namespace triples.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * There are differences in the definitions of components between different
 * SBML Levels, as well as Versions within Levels.  For example, the
 * 'sboTerm' attribute was not introduced until Level&nbsp;2
 * Version&nbsp;2, and then only on certain component classes; the SBML
 * Level&nbsp;2 Version&nbsp;3 specification moved the 'sboTerm' attribute
 * to the SBase class, thereby allowing nearly all components to have SBO
 * annotations.  As a result of differences such as those, libSBML needs to
 * track the SBML Level and Version of every object created.
 *
 * The purpose of the SBMLNamespaces object class is to make it easier to
 * communicate SBML Level and Version data between libSBML constructors and
 * other methods.  The SBMLNamespaces object class tracks 3-tuples
 * (triples) consisting of SBML Level, Version, and the corresponding SBML
 * XML namespace.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them; however, until the introduction of SBML
 * Level&nbsp;3, the SBMLNamespaces object only records one SBML
 * Level/Version/namespace combination at a time.  Most constructors for
 * SBML objects in libSBML take a SBMLNamespaces object as an argument,
 * thereby allowing the constructor to produce the proper combination of
 * attributes and other internal data structures for the given SBML Level
 * and Version.
 */

public class SBMLNamespaces : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal SBMLNamespaces(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SBMLNamespaces obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (SBMLNamespaces obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~SBMLNamespaces() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLNamespaces(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static bool operator==(SBMLNamespaces lhs, SBMLNamespaces rhs)
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

  public static bool operator!=(SBMLNamespaces lhs, SBMLNamespaces rhs)
  {
    return !(lhs == rhs);
  }

  public override bool Equals(Object sb)
  {
    if ( ! (sb is SBMLNamespaces) )
    {
      return false;
    }

    return this == (SBMLNamespaces)sb;
  }

  public override int GetHashCode()
  {
    return swigCPtr.Handle.ToInt32();
  }


/**
   * Creates a new SBMLNamespaces object corresponding to the given SBML
   * @p level and @p version.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @param level the SBML level.
   * @param version the SBML version.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 SBMLNamespaces(long level, long version) : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_0(level, version), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new SBMLNamespaces object corresponding to the given SBML
   * @p level and @p version.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @param level the SBML level.
   * @param version the SBML version.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 SBMLNamespaces(long level) : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_1(level), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new SBMLNamespaces object corresponding to the given SBML
   * @p level and @p version.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @param level the SBML level.
   * @param version the SBML version.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 SBMLNamespaces() : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_2(), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * (For extensions) Creates a new SBMLNamespaces object corresponding to
   * the combination of (1) the given SBML @p level and @p version, and (2)
   * the given @p package with the @p package @p version.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @param level   the SBML Level.
   * @param version the SBML Version.
   * @param pkgName the string of package name (e.g. 'layout', 'multi').
   * @param pkgVersion the package version.
   * @param pkgPrefix the prefix of the package namespace (e.g. 'layout', 'multi') to be added.
   *        The package's name will be used if the given string is empty (default).
   *
   * @throws SBMLExtensionException if the extension module that supports the
   * combination of the given SBML Level, SBML Version, package name, and
   * package version has not been registered with libSBML.
   */ public
 SBMLNamespaces(long level, long version, string pkgName, long pkgVersion, string pkgPrefix) : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_3(level, version, pkgName, pkgVersion, pkgPrefix), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * (For extensions) Creates a new SBMLNamespaces object corresponding to
   * the combination of (1) the given SBML @p level and @p version, and (2)
   * the given @p package with the @p package @p version.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @param level   the SBML Level.
   * @param version the SBML Version.
   * @param pkgName the string of package name (e.g. 'layout', 'multi').
   * @param pkgVersion the package version.
   * @param pkgPrefix the prefix of the package namespace (e.g. 'layout', 'multi') to be added.
   *        The package's name will be used if the given string is empty (default).
   *
   * @throws SBMLExtensionException if the extension module that supports the
   * combination of the given SBML Level, SBML Version, package name, and
   * package version has not been registered with libSBML.
   */ public
 SBMLNamespaces(long level, long version, string pkgName, long pkgVersion) : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_4(level, version, pkgName, pkgVersion), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Copy constructor; creates a copy of a SBMLNamespaces.
   *
   * @param orig the SBMLNamespaces instance to copy.
   */ public
 SBMLNamespaces(SBMLNamespaces orig) : this(libsbmlPINVOKE.new_SBMLNamespaces__SWIG_5(SBMLNamespaces.getCPtr(orig)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates and returns a deep copy of this SBMLNamespaces object.
   *
   * @return the (deep) copy of this SBMLNamespaces object.
   */ public new
 SBMLNamespaces clone() {
	SBMLNamespaces ret
	    = (SBMLNamespaces) libsbml.DowncastSBMLNamespaces(libsbmlPINVOKE.SBMLNamespaces_clone(swigCPtr), true);
	return ret;
}


/**
   * Returns a string representing the SBML XML namespace for the
   * given @p level and @p version of SBML.
   *
   * @param level the SBML level.
   * @param version the SBML version.
   *
   * @return a string representing the SBML namespace that reflects the
   * SBML Level and Version specified.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static string getSBMLNamespaceURI(long level, long version) {
    string ret = libsbmlPINVOKE.SBMLNamespaces_getSBMLNamespaceURI(level, version);
    return ret;
  }


/**
   * Returns a list of all supported SBMLNamespaces in this version of
   * libsbml.
   *
   * @return a list with supported SBML namespaces.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static  SBMLNamespacesList  getSupportedNamespaces() {
  IntPtr cPtr = libsbmlPINVOKE.SBMLNamespaces_getSupportedNamespaces();
  return (cPtr == IntPtr.Zero) ? null : new SBMLNamespacesList(cPtr, true);
}


/**
   * Frees the list of supported namespaces as generated by
   * getSupportedNamespaces().
   *
   * @param supportedNS the list to be freed.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static void freeSBMLNamespaces(SWIGTYPE_p_List supportedNS) {
    libsbmlPINVOKE.SBMLNamespaces_freeSBMLNamespaces(SWIGTYPE_p_List.getCPtr(supportedNS));
  }


/**
   * Returns a string representing the SBML XML namespace of this
   * object.
   *
   * @return a string representing the SBML namespace that reflects the
   * SBML Level and Version of this object.
   */ public new
 string getURI() {
    string ret = libsbmlPINVOKE.SBMLNamespaces_getURI(swigCPtr);
    return ret;
  }


/**
   * Get the SBML Level of this SBMLNamespaces object.
   *
   * @return the SBML Level of this SBMLNamespaces object.
   */ public
 long getLevel() { return (long)libsbmlPINVOKE.SBMLNamespaces_getLevel__SWIG_0(swigCPtr); }


/**
   * Get the SBML Version of this SBMLNamespaces object.
   *
   * @return the SBML Version of this SBMLNamespaces object.
   */ public
 long getVersion() { return (long)libsbmlPINVOKE.SBMLNamespaces_getVersion__SWIG_0(swigCPtr); }


/**
   * Get the XML namespaces list for this SBMLNamespaces object.
   *
   *
 *
 * SBMLNamespaces objects are used in libSBML to communicate SBML Level and
 * Version data between constructors and other methods.  The SBMLNamespaces
 * object class holds triples consisting of SBML Level, Version, and the
 * corresponding SBML XML namespace.  Most constructors for SBML objects in
 * libSBML take a SBMLNamespaces object as an argument, thereby allowing
 * the constructor to produce the proper combination of attributes and
 * other internal data structures for the given SBML Level and Version.
 *
 * The plural name (SBMLNamespaces) is not a mistake, because in SBML
 * Level&nbsp;3, objects may have extensions added by Level&nbsp;3 packages
 * used by a given model and therefore may have multiple namespaces
 * associated with them.  In SBML Levels below Level&nbsp;3, the
 * SBMLNamespaces object only records one SBML Level/Version/namespace
 * combination at a time.  Most constructors for SBML objects in libSBML
 * take a SBMLNamespaces object as an argument, thereby allowing the
 * constructor to produce the proper combination of attributes and other
 * internal data structures for the given SBML Level and Version.
 *
   *
   * @return the XML namespaces of this SBMLNamespaces object.
   */ public
 XMLNamespaces getNamespaces() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLNamespaces_getNamespaces__SWIG_0(swigCPtr);
    XMLNamespaces ret = (cPtr == global::System.IntPtr.Zero) ? null : new XMLNamespaces(cPtr, false);
    return ret;
  }


/**
   * Add the given XML namespaces list to the set of namespaces within this
   * SBMLNamespaces object.
   *
   * The following code gives an example of how one could add the XHTML
   * namespace to the list of namespaces recorded by the top-level
   * <code>&lt;sbml&gt;</code> element of a model.  It gives the new
   * namespace a prefix of <code>html</code>.
   * @if cpp
   * @code{.cpp}
SBMLDocument sd;
try
{
    sd = new SBMLDocument(3, 1);
}
catch (SBMLConstructorException e)
{
    // Here, have code to handle a truly exceptional situation. Candidate
    // causes include invalid combinations of SBML Level and Version
    // (impossible if hardwired as given here), running out of memory, and
    // unknown system exceptions.
}

SBMLNamespaces sn = sd->getNamespaces();
if (sn != null)
{
    sn->add('http://www.w3.org/1999/xhtml', 'html');
}
else
{
    // Handle another truly exceptional situation.
}
@endcode
@endif
@if java
@code{.java}
SBMLDocument sd;
try
{
    sd = new SBMLDocument(3, 1);
}
catch (SBMLConstructorException e)
{
    // Here, have code to handle a truly exceptional situation. Candidate
    // causes include invalid combinations of SBML Level and Version
    // (impossible if hardwired as given here), running out of memory, and
    // unknown system exceptions.
}

SBMLNamespaces sn = sd.getNamespaces();
if (sn != null)
{
    sn.add('http://www.w3.org/1999/xhtml', 'html');
}
else
{
    // Handle another truly exceptional situation.
 }
@endcode
@endif
@if python
@code{.py}
sbmlDoc = None
try:
  sbmlDoc = SBMLDocument(3, 1)
except ValueError:
  # Do something to handle exceptional situation.  Candidate
  # causes include invalid combinations of SBML Level and Version
  # (impossible if hardwired as given here), running out of memory, and
  # unknown system exceptions.

namespaces = sbmlDoc.getNamespaces()
if namespaces == None:
  # Do something to handle case of no namespaces.

status = namespaces.add('http://www.w3.org/1999/xhtml', 'html')
if status != LIBSBML_OPERATION_SUCCESS:
  # Do something to handle failure.
@endcode
@endif
@if csharp
@code{.cs}
SBMLDocument sd = null;
try
{
    sd = new SBMLDocument(3, 1);
}
catch (SBMLConstructorException e)
{
    // Here, have code to handle a truly exceptional situation.
    // Candidate causes include invalid combinations of SBML
    // Level and Version (impossible if hardwired as given here),
    // running out of memory, and unknown system exceptions.
}

XMLNamespaces sn = sd.getNamespaces();
if (sn != null)
{
    sn.add('http://www.w3.org/1999/xhtml', 'html');
}
else
{
    // Handle another truly exceptional situation.
}
@endcode
   * @endif
   *
   * @param xmlns the XML namespaces to be added.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 int addNamespaces(XMLNamespaces xmlns) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addNamespaces(swigCPtr, XMLNamespaces.getCPtr(xmlns));
    return ret;
  }


/**
   * Add an XML namespace (a pair of URI and prefix) to the set of namespaces
   * within this SBMLNamespaces object.
   *
   * @param uri    the XML namespace to be added.
   * @param prefix the prefix of the namespace to be added.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 int addNamespace(string uri, string prefix) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addNamespace(swigCPtr, uri, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Removes an XML namespace from the set of namespaces within this
   * SBMLNamespaces object.
   *
   * @param uri    the XML namespace to be added.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INDEX_EXCEEDS_SIZE LIBSBML_INDEX_EXCEEDS_SIZE@endlink
   */ public
 int removeNamespace(string uri) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_removeNamespace(swigCPtr, uri);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Add an XML namespace (a pair of URI and prefix) of a package extension
   * to the set of namespaces within this SBMLNamespaces object.
   *
   * The SBML Level and SBML Version of this object is used.
   *
   * @param pkgName the string of package name (e.g. 'layout', 'multi').
   * @param pkgVersion the package version.
   * @param prefix the prefix of the package namespace to be added.
   *        The package's name will be used if the given string is empty (default).
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   *
   * @note An XML namespace of a non-registered package extension can't be
   * added by this function (@link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   * will be returned).
   *
   * @see addNamespace(@if java String, String@endif)
   */ public
 int addPackageNamespace(string pkgName, long pkgVersion, string prefix) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPackageNamespace__SWIG_0(swigCPtr, pkgName, pkgVersion, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Add an XML namespace (a pair of URI and prefix) of a package extension
   * to the set of namespaces within this SBMLNamespaces object.
   *
   * The SBML Level and SBML Version of this object is used.
   *
   * @param pkgName the string of package name (e.g. 'layout', 'multi').
   * @param pkgVersion the package version.
   * @param prefix the prefix of the package namespace to be added.
   *        The package's name will be used if the given string is empty (default).
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   *
   * @note An XML namespace of a non-registered package extension can't be
   * added by this function (@link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   * will be returned).
   *
   * @see addNamespace(@if java String, String@endif)
   */ public
 int addPackageNamespace(string pkgName, long pkgVersion) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPackageNamespace__SWIG_1(swigCPtr, pkgName, pkgVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Add the XML namespaces of package extensions in the given XMLNamespace
   * object to the set of namespaces within this SBMLNamespaces object
   * (Non-package XML namespaces are not added by this function).
   *
   * @param xmlns the XML namespaces to be added.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   *
   * @note XML namespaces of a non-registered package extensions are not
   * added (just ignored) by this function. @link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink will be returned if the given
   * xmlns is @c null.
   */ public
 int addPackageNamespaces(XMLNamespaces xmlns) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPackageNamespaces(swigCPtr, XMLNamespaces.getCPtr(xmlns));
    return ret;
  }


/**
   * Removes an XML namespace of a package extension from the set of namespaces
   * within this SBMLNamespaces object.
   *
   * @param level   the SBML level.
   * @param version the SBML version.
   * @param pkgName the string of package name (e.g. 'layout', 'multi').
   * @param pkgVersion the package version.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_ATTRIBUTE_VALUE LIBSBML_INVALID_ATTRIBUTE_VALUE@endlink
   * @li @link libsbml#LIBSBML_INDEX_EXCEEDS_SIZE LIBSBML_INDEX_EXCEEDS_SIZE@endlink
   */ public
 int removePackageNamespace(long level, long version, string pkgName, long pkgVersion) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_removePackageNamespace(swigCPtr, level, version, pkgName, pkgVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/** */ /* libsbml-internal */ public
 int addPkgNamespace(string pkgName, long pkgVersion, string prefix) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPkgNamespace__SWIG_0(swigCPtr, pkgName, pkgVersion, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/** */ /* libsbml-internal */ public
 int addPkgNamespace(string pkgName, long pkgVersion) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPkgNamespace__SWIG_1(swigCPtr, pkgName, pkgVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/** */ /* libsbml-internal */ public
 int addPkgNamespaces(XMLNamespaces xmlns) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_addPkgNamespaces(swigCPtr, XMLNamespaces.getCPtr(xmlns));
    return ret;
  }


/** */ /* libsbml-internal */ public
 int removePkgNamespace(long level, long version, string pkgName, long pkgVersion) {
    int ret = libsbmlPINVOKE.SBMLNamespaces_removePkgNamespace(swigCPtr, level, version, pkgName, pkgVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Predicate returning @c true if the given URL is one of SBML XML
   * namespaces.
   *
   * @param uri the URI of namespace.
   *
   * @return @c true if the 'uri' is one of SBML namespaces, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isSBMLNamespace(string uri) {
    bool ret = libsbmlPINVOKE.SBMLNamespaces_isSBMLNamespace(uri);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Predicate returning @c true if the given set of namespaces represent a
   * valid set
   *
   * @return @c true if the set of namespaces is valid, @c false otherwise.
   */ public
 bool isValidCombination() {
    bool ret = libsbmlPINVOKE.SBMLNamespaces_isValidCombination(swigCPtr);
    return ret;
  }


/**
   * Returns the name of the main package for this namespace.
   *
   * @return the name of the main package for this namespace.
   * 'core' will be returned if this namespace is defined in the SBML
   * core.
   */ public new
 string getPackageName() {
    string ret = libsbmlPINVOKE.SBMLNamespaces_getPackageName(swigCPtr);
    return ret;
  }

}

}
