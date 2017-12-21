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

 using System;
 using System.Runtime.InteropServices;

/**
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html File and text-string SBML reader.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * The SBMLReader class provides the main interface for reading SBML content
 * from files and strings.  The methods for reading SBML all return an
 * SBMLDocument object representing the results.  In the case of failures
 * (such as if the SBML contains errors or a file cannot be read), the errors
 * will be recorded with the SBMLErrorLog object kept in the SBMLDocument
 * returned by SBMLReader.  Consequently, immediately after calling a method
 * on SBMLReader, callers should always check for errors and warnings using
 * the methods for this purpose provided by SBMLDocument.
 *
 * For convenience as well as easy access from other languages besides C++,
 * this file also defines two global functions,
 * @sbmlglobalfunction{readSBML, String} and
 * @sbmlglobalfunction{readSBMLFromString, String}.  They are
 * equivalent to creating an SBMLReader object and then calling the
 * @if python @link SBMLReader::readSBML() SBMLReader.readSBML()@endlink@endif@if java SBMLReader::readSBML(String)@endif@if cpp SBMLReader::readSBML()@endif@if csharp SBMLReader.readSBML()@endif and
 * @if python @link SBMLReader::readSBMLFromString() SBMLReader.readSBMLFromString()@endlink@endif@if java SBMLReader::readSBMLFromString(String)@endif@if cpp SBMLReader::readSBMLFromString()@endif@if csharp SBMLReader.readSBMLFromString()@endif methods, respectively.
 *
 * @section compression Support for reading compressed files
 *
 * LibSBML provides support for reading (as well as writing) compressed
 * SBML files.  The process is transparent to the calling
 * application---the application does not need to do anything
 * deliberate to invoke the functionality.  If a given SBML filename ends
 * with an extension for the @em gzip, @em zip or @em bzip2 compression
 * formats (respectively, @c .gz, @c .zip, or @c .bz2), then the methods
 * @if python @link SBMLReader::readSBML() SBMLReader.readSBML()@endlink@endif@if java @link SBMLReader::readSBML(String) SBMLReader.readSBML(String)@endlink@endif@if cpp SBMLReader::readSBML()@endif@if csharp SBMLReader.readSBML()@endif and
 * @if python @link SBMLWriter::writeSBML() SBMLWriter.writeSBML()@endlink@endif@if java @link SBMLWriter::writeSBML(String) SBMLWriter.writeSBML(String)@endlink@endif@if cpp SBMLWriter::writeSBML()@endif@if csharp SBMLWriter.writeSBML()@endif
 * will automatically decompress and compress the file while reading and
 * writing it.  If the filename has no such extension, it will be read and
 * written uncompressed as normal.
 *
 * The compression feature requires that the @em zlib (for @em gzip and @em
 * zip formats) and/or @em bzip2 (for @em bzip2 format) be available on the
 * system running libSBML, and that libSBML was configured with their
 * support compiled-in.  Please see the libSBML
 * @if java <a href='../../../libsbml-installation.html'>installation instructions</a> @else <a href='libsbml-installation.html'>installation instructions</a>@endif
 * for more information about this.  The methods
 * @if java SBMLReader::hasZlib()@else hasZlib()@endif and
 * @if java SBMLReader::hasBzip2()@else hasBzip2()@endif
 * can be used by an application to query at run-time whether support
 * for the compression libraries is available in the present copy of
 * libSBML.
 *
 * Support for compression is not mandated by the SBML standard, but
 * applications may find it helpful, particularly when large SBML models
 * are being communicated across data links of limited bandwidth.
 */

public class SBMLReader : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal SBMLReader(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SBMLReader obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (SBMLReader obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~SBMLReader() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLReader(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static bool operator==(SBMLReader lhs, SBMLReader rhs)
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

  public static bool operator!=(SBMLReader lhs, SBMLReader rhs)
  {
    return !(lhs == rhs);
  }

  public override bool Equals(Object sb)
  {
    if ( ! (sb is SBMLReader) )
    {
      return false;
    }

    return this == (SBMLReader)sb;
  }

  public override int GetHashCode()
  {
    return swigCPtr.Handle.ToInt32();
  }


/**
   * Creates a new SBMLReader object and returns it.
   *
   * The libSBML SBMLReader object offers methods for reading SBML in
   * XML form from files and text strings.
   */ public
 SBMLReader() : this(libsbmlPINVOKE.new_SBMLReader(), true) {
  }


/**
   *
 * Reads an SBML document from the given file.
 *
 * If the file named @p filename does not exist or its content is not valid
 * SBML, one or more errors will be logged with the SBMLDocument object
 * returned by this method.  Callers can use the methods on SBMLDocument such
 * as
 * @if python @link libsbml.SBMLDocument.getNumErrors() SBMLDocument.getNumErrors()@endlink@endif,
 * @if conly SBMLDocument_getNumErrors() @else SBMLDocument::getNumErrors()@endif
 * and
 * @if python @link libsbml.SBMLDocument.getError() SBMLDocument.getError()@endlink@endif
 * @if java SBMLDocument::getError(long)@endif
 * @if cpp SBMLDocument::getError()@endif
 * @if csharp SBMLDocument::getError()@endif
 * @if conly SBMLDocument_getError()@endif
 * to get the errors.  The object returned by
 * @if python @link libsbml.SBMLDocument.getError() SBMLDocument.getError()@endlink@endif
 * @if java SBMLDocument::getError(long)@endif
 * @if cpp SBMLDocument::getError()@endif
 * @if csharp SBMLDocument::getError()@endif
 * @if conly SBMLDocument_getError()@endif
 * is an SBMLError object, and it has methods to get the error code,
 * category, and severity level of the problem, as well as a textual
 * description of the problem.  The possible severity levels range from
 * informational messages to fatal errors; see the documentation for
 * @if conly SBMLError_t @else SBMLError@endif
 * for more information.
 *
 * If the file @p filename could not be read, the file-reading error will
 * appear first.  The error code @if clike (a value drawn from the
 * enumeration #XMLErrorCode_t)@endif can provide a clue about what
 * happened.  For example, a file might be unreadable (either because it does
 * not actually exist or because the user does not have the necessary access
 * privileges to read it) or some sort of file operation error may have been
 * reported by the underlying operating system.  Callers can check for these
 * situations using a program fragment such as the following:
 * @if cpp
@code{.cpp}
SBMLReader reader;
SBMLDocument doc  = reader.readSBMLFromFile(filename);

if (doc->getNumErrors() > 0)
{
  if (doc->getError(0)->getErrorId() == XMLError::XMLFileUnreadable)
  {
    // Handle case of unreadable file here.
  }
  else if (doc->getError(0)->getErrorId() == XMLError::XMLFileOperationError)
  {
    // Handle case of other file operation error here.
  }
  else
  {
    // Handle other cases -- see error codes defined in XMLErrorCode_t
    // for other possible cases to check.
  }
}
@endcode
@endif
@if conly
@code{.c}
SBMLReader_t   *sr;
SBMLDocument_t *d;

sr = SBMLReader_create();

d = SBMLReader_readSBML(sr, filename);

if (SBMLDocument_getNumErrors(d) > 0)
{
  if (XMLError_getId(SBMLDocument_getError(d, 0))
      == SBML_READ_ERROR_FILE_NOT_FOUND)
  {
     ...
  }
  if (XMLError_getId(SBMLDocument_getError(d, 0))
      == SBML_READ_ERROR_NOT_SBML)
  {
     ...
  }
}
@endcode
@endif
@if java
@code{.java}
SBMLReader reader = new SBMLReader();
SBMLDocument doc  = reader.readSBMLFromFile(filename);

if (doc.getNumErrors() > 0)
{
    if (doc.getError(0).getErrorId() == libsbml.libsbml.XMLFileUnreadable)
    {
        // Handle case of unreadable file here.
    }
    else if (doc.getError(0).getErrorId() == libsbml.libsbml.XMLFileOperationError)
    {
        // Handle case of other file operation error here.
    }
    else
    {
        // Handle other error cases.
    }
}
@endcode
@endif
@if python
@code{.py}
reader = SBMLReader()
if reader == None:
  # Handle the truly exceptional case of no object created here.

doc = reader.readSBMLFromFile(filename)
if doc.getNumErrors() > 0:
  if doc.getError(0).getErrorId() == XMLFileUnreadable:
    # Handle case of unreadable file here.
  elif doc.getError(0).getErrorId() == XMLFileOperationError:
    # Handle case of other file error here.
  else:
    # Handle other error cases here.
@endcode
@endif
@if csharp
@code{.cs}
SBMLReader reader = new SBMLReader();
SBMLDocument doc = reader.readSBMLFromFile(filename);

if (doc.getNumErrors() > 0)
{
    if (doc.getError(0).getErrorId() == libsbmlcs.libsbml.XMLFileUnreadable)
    {
         // Handle case of unreadable file here.
    }
    else if (doc.getError(0).getErrorId() == libsbmlcs.libsbml.XMLFileOperationError)
    {
         // Handle case of other file operation error here.
    }
    else
    {
         // Handle other cases -- see error codes defined in XMLErrorCode_t
         // for other possible cases to check.
    }
 }
@endcode
@endif
 *
 *
 *
 * If the given filename ends with the suffix @c '.gz' (for example,
 * @c 'myfile.xml.gz'), the file is assumed to be compressed in @em gzip
 * format and will be automatically decompressed upon reading.
 * Similarly, if the given filename ends with @c '.zip' or @c '.bz2', the
 * file is assumed to be compressed in @em zip or @em bzip2 format
 * (respectively).  Files whose names lack these suffixes will be read
 * uncompressed.  Note that if the file is in @em zip format but the
 * archive contains more than one file, only the first file in the
 * archive will be read and the rest ignored.
 *
 *
 *
 *
 *
 * To read a gzip/zip file, libSBML needs to be configured and linked with the
 * <a target='_blank' href='http://www.zlib.net/'>zlib</a> library at compile
 * time.  It also needs to be linked with the <a target='_blank'
 * href=''>bzip2</a> library to read files in <em>bzip2</em> format.  (Both of
 * these are the default configurations for libSBML.)  Errors about unreadable
 * files will be logged if a compressed filename is given and libSBML was
 * <em>not</em> linked with the corresponding required library.
 *
 *
 *
 *
   *
   * This method is identical to
   * @if python @link SBMLReader::readSBMLFromFile() SBMLReader.readSBMLFromFile()@endlink@endif@if java @link SBMLReader::readSBMLFromFile(String) SBMLReader.readSBMLFromFile(String)@endlink@endif@if cpp SBMLReader::readSBMLFromFile()@endif@if csharp SBMLReader.readSBMLFromFile()@endif.
   *
   * @param filename the name or full pathname of the file to be read.
   *
   * @return a pointer to the SBMLDocument object created from the SBML
   * content in @p filename.
   *
   *
 * @note LibSBML versions 2.x and later versions behave differently in
 * error handling in several respects.  One difference is how early some
 * errors are caught and whether libSBML continues processing a file in
 * the face of some early errors.  In general, libSBML versions after 2.x
 * stop parsing SBML inputs sooner than libSBML version 2.x in the face
 * of XML errors, because the errors may invalidate any further SBML
 * content.  For example, a missing XML declaration at the beginning of
 * the file was ignored by libSBML 2.x but in version 3.x and later, it
 * will cause libSBML to stop parsing the rest of the input altogether.
 * While this behavior may seem more severe and intolerant, it was
 * necessary in order to provide uniform behavior regardless of which
 * underlying XML parser (Expat, Xerces, libxml2) is being used by
 * libSBML.  The XML parsers themselves behave differently in their error
 * reporting, and sometimes libSBML has to resort to the lowest common
 * denominator.
 *
 *
   *
   * @see readSBMLFromString(@if java String@endif)
   * @see SBMLError
   * @see SBMLDocument
   */ public
 SBMLDocument readSBML(string filename) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLReader_readSBML(swigCPtr, filename);
    SBMLDocument ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLDocument(cPtr, true);
    return ret;
  }


/**
   *
 * Reads an SBML document from the given file.
 *
 * If the file named @p filename does not exist or its content is not valid
 * SBML, one or more errors will be logged with the SBMLDocument object
 * returned by this method.  Callers can use the methods on SBMLDocument such
 * as
 * @if python @link libsbml.SBMLDocument.getNumErrors() SBMLDocument.getNumErrors()@endlink@endif,
 * @if conly SBMLDocument_getNumErrors() @else SBMLDocument::getNumErrors()@endif
 * and
 * @if python @link libsbml.SBMLDocument.getError() SBMLDocument.getError()@endlink@endif
 * @if java SBMLDocument::getError(long)@endif
 * @if cpp SBMLDocument::getError()@endif
 * @if csharp SBMLDocument::getError()@endif
 * @if conly SBMLDocument_getError()@endif
 * to get the errors.  The object returned by
 * @if python @link libsbml.SBMLDocument.getError() SBMLDocument.getError()@endlink@endif
 * @if java SBMLDocument::getError(long)@endif
 * @if cpp SBMLDocument::getError()@endif
 * @if csharp SBMLDocument::getError()@endif
 * @if conly SBMLDocument_getError()@endif
 * is an SBMLError object, and it has methods to get the error code,
 * category, and severity level of the problem, as well as a textual
 * description of the problem.  The possible severity levels range from
 * informational messages to fatal errors; see the documentation for
 * @if conly SBMLError_t @else SBMLError@endif
 * for more information.
 *
 * If the file @p filename could not be read, the file-reading error will
 * appear first.  The error code @if clike (a value drawn from the
 * enumeration #XMLErrorCode_t)@endif can provide a clue about what
 * happened.  For example, a file might be unreadable (either because it does
 * not actually exist or because the user does not have the necessary access
 * privileges to read it) or some sort of file operation error may have been
 * reported by the underlying operating system.  Callers can check for these
 * situations using a program fragment such as the following:
 * @if cpp
@code{.cpp}
SBMLReader reader;
SBMLDocument doc  = reader.readSBMLFromFile(filename);

if (doc->getNumErrors() > 0)
{
  if (doc->getError(0)->getErrorId() == XMLError::XMLFileUnreadable)
  {
    // Handle case of unreadable file here.
  }
  else if (doc->getError(0)->getErrorId() == XMLError::XMLFileOperationError)
  {
    // Handle case of other file operation error here.
  }
  else
  {
    // Handle other cases -- see error codes defined in XMLErrorCode_t
    // for other possible cases to check.
  }
}
@endcode
@endif
@if conly
@code{.c}
SBMLReader_t   *sr;
SBMLDocument_t *d;

sr = SBMLReader_create();

d = SBMLReader_readSBML(sr, filename);

if (SBMLDocument_getNumErrors(d) > 0)
{
  if (XMLError_getId(SBMLDocument_getError(d, 0))
      == SBML_READ_ERROR_FILE_NOT_FOUND)
  {
     ...
  }
  if (XMLError_getId(SBMLDocument_getError(d, 0))
      == SBML_READ_ERROR_NOT_SBML)
  {
     ...
  }
}
@endcode
@endif
@if java
@code{.java}
SBMLReader reader = new SBMLReader();
SBMLDocument doc  = reader.readSBMLFromFile(filename);

if (doc.getNumErrors() > 0)
{
    if (doc.getError(0).getErrorId() == libsbml.libsbml.XMLFileUnreadable)
    {
        // Handle case of unreadable file here.
    }
    else if (doc.getError(0).getErrorId() == libsbml.libsbml.XMLFileOperationError)
    {
        // Handle case of other file operation error here.
    }
    else
    {
        // Handle other error cases.
    }
}
@endcode
@endif
@if python
@code{.py}
reader = SBMLReader()
if reader == None:
  # Handle the truly exceptional case of no object created here.

doc = reader.readSBMLFromFile(filename)
if doc.getNumErrors() > 0:
  if doc.getError(0).getErrorId() == XMLFileUnreadable:
    # Handle case of unreadable file here.
  elif doc.getError(0).getErrorId() == XMLFileOperationError:
    # Handle case of other file error here.
  else:
    # Handle other error cases here.
@endcode
@endif
@if csharp
@code{.cs}
SBMLReader reader = new SBMLReader();
SBMLDocument doc = reader.readSBMLFromFile(filename);

if (doc.getNumErrors() > 0)
{
    if (doc.getError(0).getErrorId() == libsbmlcs.libsbml.XMLFileUnreadable)
    {
         // Handle case of unreadable file here.
    }
    else if (doc.getError(0).getErrorId() == libsbmlcs.libsbml.XMLFileOperationError)
    {
         // Handle case of other file operation error here.
    }
    else
    {
         // Handle other cases -- see error codes defined in XMLErrorCode_t
         // for other possible cases to check.
    }
 }
@endcode
@endif
 *
 *
 *
 * If the given filename ends with the suffix @c '.gz' (for example,
 * @c 'myfile.xml.gz'), the file is assumed to be compressed in @em gzip
 * format and will be automatically decompressed upon reading.
 * Similarly, if the given filename ends with @c '.zip' or @c '.bz2', the
 * file is assumed to be compressed in @em zip or @em bzip2 format
 * (respectively).  Files whose names lack these suffixes will be read
 * uncompressed.  Note that if the file is in @em zip format but the
 * archive contains more than one file, only the first file in the
 * archive will be read and the rest ignored.
 *
 *
 *
 *
 *
 * To read a gzip/zip file, libSBML needs to be configured and linked with the
 * <a target='_blank' href='http://www.zlib.net/'>zlib</a> library at compile
 * time.  It also needs to be linked with the <a target='_blank'
 * href=''>bzip2</a> library to read files in <em>bzip2</em> format.  (Both of
 * these are the default configurations for libSBML.)  Errors about unreadable
 * files will be logged if a compressed filename is given and libSBML was
 * <em>not</em> linked with the corresponding required library.
 *
 *
 *
 *
   *
   * This method is identical to
   * @if python @link SBMLReader::readSBML() SBMLReader.readSBML()@endlink@endif@if java @link SBMLReader::readSBML(String) SBMLReader.readSBML(String)@endlink@endif@if cpp SBMLReader::readSBML()@endif@if csharp SBMLReader.readSBML()@endif.
   *
   * @param filename the name or full pathname of the file to be read.
   *
   * @return a pointer to the SBMLDocument object created from the SBML
   * content in @p filename.
   *
   *
 * @note LibSBML versions 2.x and later versions behave differently in
 * error handling in several respects.  One difference is how early some
 * errors are caught and whether libSBML continues processing a file in
 * the face of some early errors.  In general, libSBML versions after 2.x
 * stop parsing SBML inputs sooner than libSBML version 2.x in the face
 * of XML errors, because the errors may invalidate any further SBML
 * content.  For example, a missing XML declaration at the beginning of
 * the file was ignored by libSBML 2.x but in version 3.x and later, it
 * will cause libSBML to stop parsing the rest of the input altogether.
 * While this behavior may seem more severe and intolerant, it was
 * necessary in order to provide uniform behavior regardless of which
 * underlying XML parser (Expat, Xerces, libxml2) is being used by
 * libSBML.  The XML parsers themselves behave differently in their error
 * reporting, and sometimes libSBML has to resort to the lowest common
 * denominator.
 *
 *
   *
   * @see readSBMLFromString(@if java String@endif)
   * @see SBMLError
   * @see SBMLDocument
   */ public
 SBMLDocument readSBMLFromFile(string filename) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLReader_readSBMLFromFile(swigCPtr, filename);
    SBMLDocument ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLDocument(cPtr, true);
    return ret;
  }


/**
   *
 * Reads an SBML document from a text string.
 *
 * This method is flexible with respect to the presence of an XML
 * declaration at the beginning of the string.  In particular, if the
 * string in @p xml does not begin with the XML declaration
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * then this method will automatically prepend the declaration
 * to @p xml.
 *
 * This method will log a fatal error if the content given in the parameter
 * @p xml is not in SBML format.  See the method documentation for
 * @if conly SBMLReader_readSBML()
 * @elseif java SBMLReader::readSBML( String )
 * @else SBMLReader::readSBML()
 * @endif
 * for an example of code for testing the returned error code.
 *
 *
   *
   * @param xml a string containing a full SBML model.
   *
   * @return a pointer to the SBMLDocument created from the SBML content,
   * or a null pointer if @p xml is @c null.
   *
   *
 * @note When using this method to read an SBMLDocument that uses the SBML
 * Level&nbsp;3 Hierarchical %Model Composition package (comp) the document
 * location cannot be set automatically. Thus, if the model contains
 * references to ExternalModelDefinition objects, it will be necessary to
 * manually set the document URI location
 * (@if conly SBMLDocument_setLocationURI()
 * @elseif java SBMLDocument::setLocationURI( String )
 * @else SBMLDocument::setLocationURI()
 * @endif
 * ) in order to facilitate resolving these models.
   *
   * @see SBMLReader::readSBML(@if java String@endif)
   */ public
 SBMLDocument readSBMLFromString(string xml) {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLReader_readSBMLFromString(swigCPtr, xml);
    SBMLDocument ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLDocument(cPtr, true);
    return ret;
  }


/**
   * Static method; returns @c true if this copy of libSBML supports
   * <i>gzip</I> and <i>zip</i> format compression.
   *
   * @return @c true if libSBML has been linked with the <i>zlib</i>
   * library, @c false otherwise.
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
   *
   * @see @if clike hasBzip2() @else SBMLReader::hasBzip2()@endif
   */ public
 static bool hasZlib() {
    bool ret = libsbmlPINVOKE.SBMLReader_hasZlib();
    return ret;
  }


/**
   * Static method; returns @c true if this copy of libSBML supports
   * <i>bzip2</i> format compression.
   *
   * @return @c true if libSBML is linked with the <i>bzip2</i>
   * libraries, @c false otherwise.
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
   *
   * @see @if clike hasZlib() @else SBMLReader::hasZlib()@endif
   */ public
 static bool hasBzip2() {
    bool ret = libsbmlPINVOKE.SBMLReader_hasBzip2();
    return ret;
  }

}

}
