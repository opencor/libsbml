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
@htmlinclude pkg-marker-core.html Interface to an XML output stream.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * SBML content is serialized using XML; the resulting data can be stored and
 * read to/from a file or data stream.  Low-level XML parsers such as Xerces
 * provide facilities to read XML data.  To permit the use of different XML
 * parsers (Xerces, Expat or libxml2), libSBML implements an abstraction
 * layer.  XMLInputStream and XMLOutputStream are two parts of that
 * abstraction layer.
 *
 * XMLOutputStream provides a wrapper above output streams to facilitate
 * writing XML.  XMLOutputStream keeps track of start and end elements,
 * indentation, XML namespace prefixes, and more.  The interface provides
 * features for converting non-text data types into appropriate textual form;
 * this takes the form of overloaded <code>writeAttribute(...)</code> methods
 * that allow users to simply use the same method with any data type.  For
 * example, suppose an element @c testElement has two attributes, @c size and
 * @c id, and the attributes are variables in your code as follows:
@if cpp
@code{.cpp}
double size = 3.2;
string id = 'id';
@endcode
@endif
@if java
@code
double size = 3.2;
String id = 'id';
@endcode
@endif
@if python
@code
size = 3.2;
id = 'id';
@endcode
@endif
  * Then, the element and the attributes can be written to the
  * standard output stream @ifnot cpp (provided as @c cout in the libSBML
  * language bindings)@endif as follows:
@if cpp
@code{.cpp}
double size = 3.2;
string id = 'id';

// Create an XMLOutputStream object that will write to the
// standard output stream:

XMLOutputStream xos = new XMLOutputStream(cout);

// Create the start element, write the attributes, and close
// the element.  The output will be written immediately as
// each method is called.

xos.startElement('testElement')
xos.writeAttribute('size', size)
xos.writeAttribute('id', id)
xos.endElement('testElement')
@endcode
@endif
@if java
@code{.java}
import org.sbml.libsbml.XMLOutputStream;
import org.sbml.libsbml.libsbml;

public class test
{
    public static void main (String[] args)
    {
        double size = 3.2;
        String id = 'id';

        // Create an XMLOutputStream object that will write to the
        // standard output stream, which is provide in libSBML's
        // Java language interface as the object 'libsbml.cout'.

        XMLOutputStream xos = new XMLOutputStream(libsbml.cout);

        // Create the start element, write the attributes, and close
        // the element.  The output will be written immediately as
        // each method is called.

        xos.startElement('testElement');
        xos.writeAttribute('size', size);
        xos.writeAttribute('id', id);
        xos.endElement('testElement');
    }

    static
    {
        System.loadLibrary('sbmlj');
    }
}
@endcode
@endif
@if python
@code{.py}
from libsbml import *

size = 3.2;
id = 'id';

# Create an XMLOutputStream object that will write to the standard
# output stream, which is provide in libSBML's Python language
# interface as the object 'libsbml.cout'.  Since we imported * from
# the libsbml module, we can simply refer to it as 'cout' here:

output_stream = XMLOutputStream(cout)

# Create the start element, write the attributes, and close the
# element.  The output is written immediately by each method.

output_stream.startElement('testElement')
output_stream.writeAttribute('size', size)
output_stream.writeAttribute('id', id)
output_stream.endElement('testElement')
@endcode
@endif
 *
 * Other classes in SBML take XMLOutputStream objects as arguments, and use
 * that to write elements and attributes seamlessly to the XML output stream.
 *
 * It is also worth noting that unlike XMLInputStream, XMLOutputStream is
 * actually independent of the underlying XML parsers.  It does not use the
 * XML parser libraries at all.
 *
 * @note The convenience of the XMLInputStream and XMLOutputStream
 * abstraction may be useful for developers interested in creating parsers
 * for other XML formats besides SBML.  It can provide developers with a
 * layer above more basic XML parsers, as well as some useful programmatic
 * elements such as XMLToken, XMLError, etc.
 *
 * @see XMLInputStream
 */

public class XMLOutputStream : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal XMLOutputStream(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(XMLOutputStream obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (XMLOutputStream obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~XMLOutputStream() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_XMLOutputStream(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static bool operator==(XMLOutputStream lhs, XMLOutputStream rhs)
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

  public static bool operator!=(XMLOutputStream lhs, XMLOutputStream rhs)
  {
    return !(lhs == rhs);
  }

  public override bool Equals(Object sb)
  {
    if ( ! (sb is XMLOutputStream) )
    {
      return false;
    }

    return this == (XMLOutputStream)sb;
  }

  public override int GetHashCode()
  {
    return swigCPtr.Handle.ToInt32();
  }


/**
   * Creates a new XMLOutputStream that wraps the given @p stream.
   *
   *
 *
 * The functionality associated with the @p programName and @p
 * programVersion arguments concerns an optional comment that libSBML can
 * write at the beginning of the output stream.  The comment is intended
 * for human readers of the XML file, and has the following form:
 * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
 *
 * This program information comment is a separate item from the XML
 * declaration that this method can also write to this output stream.  The
 * comment is also not mandated by any SBML specification.  This libSBML
 * functionality is provided for the convenience of calling programs, and to
 * help humans trace the origin of SBML files.
 *
 *
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   *
   * @param stream the input stream to wrap.
   *
   * @param encoding the XML encoding to declare in the output. This value
   * should be <code>'UTF-8'</code> for SBML documents.  The default value
   * is <code>'UTF-8'</code> if no value is supplied for this parameter.
   *
   * @param writeXMLDecl whether to write a standard XML declaration at
   * the beginning of the content written on @p stream.  The default is
   * @c true.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 XMLOutputStream(OStream stream, string encoding, bool writeXMLDecl, string programName, string programVersion) : this(libsbmlPINVOKE.new_XMLOutputStream__SWIG_0(SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()), encoding, writeXMLDecl, programName, programVersion), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new XMLOutputStream that wraps the given @p stream.
   *
   *
 *
 * The functionality associated with the @p programName and @p
 * programVersion arguments concerns an optional comment that libSBML can
 * write at the beginning of the output stream.  The comment is intended
 * for human readers of the XML file, and has the following form:
 * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
 *
 * This program information comment is a separate item from the XML
 * declaration that this method can also write to this output stream.  The
 * comment is also not mandated by any SBML specification.  This libSBML
 * functionality is provided for the convenience of calling programs, and to
 * help humans trace the origin of SBML files.
 *
 *
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   *
   * @param stream the input stream to wrap.
   *
   * @param encoding the XML encoding to declare in the output. This value
   * should be <code>'UTF-8'</code> for SBML documents.  The default value
   * is <code>'UTF-8'</code> if no value is supplied for this parameter.
   *
   * @param writeXMLDecl whether to write a standard XML declaration at
   * the beginning of the content written on @p stream.  The default is
   * @c true.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 XMLOutputStream(OStream stream, string encoding, bool writeXMLDecl, string programName) : this(libsbmlPINVOKE.new_XMLOutputStream__SWIG_1(SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()), encoding, writeXMLDecl, programName), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new XMLOutputStream that wraps the given @p stream.
   *
   *
 *
 * The functionality associated with the @p programName and @p
 * programVersion arguments concerns an optional comment that libSBML can
 * write at the beginning of the output stream.  The comment is intended
 * for human readers of the XML file, and has the following form:
 * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
 *
 * This program information comment is a separate item from the XML
 * declaration that this method can also write to this output stream.  The
 * comment is also not mandated by any SBML specification.  This libSBML
 * functionality is provided for the convenience of calling programs, and to
 * help humans trace the origin of SBML files.
 *
 *
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   *
   * @param stream the input stream to wrap.
   *
   * @param encoding the XML encoding to declare in the output. This value
   * should be <code>'UTF-8'</code> for SBML documents.  The default value
   * is <code>'UTF-8'</code> if no value is supplied for this parameter.
   *
   * @param writeXMLDecl whether to write a standard XML declaration at
   * the beginning of the content written on @p stream.  The default is
   * @c true.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 XMLOutputStream(OStream stream, string encoding, bool writeXMLDecl) : this(libsbmlPINVOKE.new_XMLOutputStream__SWIG_2(SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()), encoding, writeXMLDecl), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new XMLOutputStream that wraps the given @p stream.
   *
   *
 *
 * The functionality associated with the @p programName and @p
 * programVersion arguments concerns an optional comment that libSBML can
 * write at the beginning of the output stream.  The comment is intended
 * for human readers of the XML file, and has the following form:
 * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
 *
 * This program information comment is a separate item from the XML
 * declaration that this method can also write to this output stream.  The
 * comment is also not mandated by any SBML specification.  This libSBML
 * functionality is provided for the convenience of calling programs, and to
 * help humans trace the origin of SBML files.
 *
 *
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   *
   * @param stream the input stream to wrap.
   *
   * @param encoding the XML encoding to declare in the output. This value
   * should be <code>'UTF-8'</code> for SBML documents.  The default value
   * is <code>'UTF-8'</code> if no value is supplied for this parameter.
   *
   * @param writeXMLDecl whether to write a standard XML declaration at
   * the beginning of the content written on @p stream.  The default is
   * @c true.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 XMLOutputStream(OStream stream, string encoding) : this(libsbmlPINVOKE.new_XMLOutputStream__SWIG_3(SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream()), encoding), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Creates a new XMLOutputStream that wraps the given @p stream.
   *
   *
 *
 * The functionality associated with the @p programName and @p
 * programVersion arguments concerns an optional comment that libSBML can
 * write at the beginning of the output stream.  The comment is intended
 * for human readers of the XML file, and has the following form:
 * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
 *
 * This program information comment is a separate item from the XML
 * declaration that this method can also write to this output stream.  The
 * comment is also not mandated by any SBML specification.  This libSBML
 * functionality is provided for the convenience of calling programs, and to
 * help humans trace the origin of SBML files.
 *
 *
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   *
   * @param stream the input stream to wrap.
   *
   * @param encoding the XML encoding to declare in the output. This value
   * should be <code>'UTF-8'</code> for SBML documents.  The default value
   * is <code>'UTF-8'</code> if no value is supplied for this parameter.
   *
   * @param writeXMLDecl whether to write a standard XML declaration at
   * the beginning of the content written on @p stream.  The default is
   * @c true.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 XMLOutputStream(OStream stream) : this(libsbmlPINVOKE.new_XMLOutputStream__SWIG_4(SWIGTYPE_p_std__ostream.getCPtr(stream.get_ostream())), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML end element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void endElement(string name, string prefix) {
    libsbmlPINVOKE.XMLOutputStream_endElement__SWIG_0(swigCPtr, name, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML end element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void endElement(string name) {
    libsbmlPINVOKE.XMLOutputStream_endElement__SWIG_1(swigCPtr, name);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given element to the stream.
   *
   * @param triple the XML element to write.
   */ public
 void endElement(XMLTriple triple, bool text) {
    libsbmlPINVOKE.XMLOutputStream_endElement__SWIG_2(swigCPtr, XMLTriple.getCPtr(triple), text);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given element to the stream.
   *
   * @param triple the XML element to write.
   */ public
 void endElement(XMLTriple triple) {
    libsbmlPINVOKE.XMLOutputStream_endElement__SWIG_3(swigCPtr, XMLTriple.getCPtr(triple));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Turns automatic indentation on or off for this XMLOutputStream.
   *
   * @param indent if @c true, automatic indentation is turned on.
   */ public
 void setAutoIndent(bool indent) {
    libsbmlPINVOKE.XMLOutputStream_setAutoIndent(swigCPtr, indent);
  }


/**
   * Writes the given XML start element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void startElement(string name, string prefix) {
    libsbmlPINVOKE.XMLOutputStream_startElement__SWIG_0(swigCPtr, name, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML start element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void startElement(string name) {
    libsbmlPINVOKE.XMLOutputStream_startElement__SWIG_1(swigCPtr, name);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML start element
   * <code><em>prefix</em>:<em>name</em></code> on this output stream.
   *
   * @param triple the start element to write.
   */ public
 void startElement(XMLTriple triple) {
    libsbmlPINVOKE.XMLOutputStream_startElement__SWIG_2(swigCPtr, XMLTriple.getCPtr(triple));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML start and end element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void startEndElement(string name, string prefix) {
    libsbmlPINVOKE.XMLOutputStream_startEndElement__SWIG_0(swigCPtr, name, prefix);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given XML start and end element name to this XMLOutputStream.
   *
   * @param name the name of the element.
   *
   * @param prefix an optional XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)
   *
   * @ifnot hasDefaultArgs @htmlinclude warn-default-args-in-docs.html @endif
   */ public
 void startEndElement(string name) {
    libsbmlPINVOKE.XMLOutputStream_startEndElement__SWIG_1(swigCPtr, name);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given start element to this output stream.
   *
   * @param triple the XML element to write.
   */ public
 void startEndElement(XMLTriple triple) {
    libsbmlPINVOKE.XMLOutputStream_startEndElement__SWIG_2(swigCPtr, XMLTriple.getCPtr(triple));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_0(swigCPtr, name, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given namespace-prefixed attribute value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param prefix an XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)  See other versions of
   * this method for a variant that does not require a prefix.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string prefix, string value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_1(swigCPtr, name, prefix, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param triple the attribute, in the form of an XMLTriple.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(XMLTriple triple, string value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_2(swigCPtr, XMLTriple.getCPtr(triple), value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, bool value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_6(swigCPtr, name, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given namespace-prefixed attribute value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param prefix an XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)  See other versions of
   * this method for a variant that does not require a prefix.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string prefix, bool value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_7(swigCPtr, name, prefix, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param triple the attribute, in the form of an XMLTriple.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(XMLTriple triple, bool value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_8(swigCPtr, XMLTriple.getCPtr(triple), value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, double value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_9(swigCPtr, name, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given namespace-prefixed attribute value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param prefix an XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)  See other versions of
   * this method for a variant that does not require a prefix.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string prefix, double value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_10(swigCPtr, name, prefix, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param triple the attribute, in the form of an XMLTriple.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(XMLTriple triple, double value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_11(swigCPtr, XMLTriple.getCPtr(triple), value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, int value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_12(swigCPtr, name, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given namespace-prefixed attribute value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param prefix an XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)  See other versions of
   * this method for a variant that does not require a prefix.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string prefix, int value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_13(swigCPtr, name, prefix, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given attribute and value to this output stream.
   *
   * @param triple the attribute, in the form of an XMLTriple.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(XMLTriple triple, int value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_14(swigCPtr, XMLTriple.getCPtr(triple), value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes the given namespace-prefixed attribute value to this output stream.
   *
   * @param name the name of the attribute.
   *
   * @param prefix an XML namespace prefix to write in front of the
   * @p element name.  (The result has the form
   * <code><em>prefix</em>:<em>name</em></code>.)  See other versions of
   * this method for a variant that does not require a prefix.
   *
   * @param value the value of the attribute.
   */ public
 void writeAttribute(string name, string prefix, long value) {
    libsbmlPINVOKE.XMLOutputStream_writeAttribute__SWIG_18(swigCPtr, name, prefix, value);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes a standard XML declaration to this output stream.
   *
   *
 *
 * The XML declaration has the form
 * @verbatim
<?xml version='1.0' encoding='UTF-8'?>
@endverbatim
 * Note that the SBML specifications require the use of UTF-8 encoding and
 * version 1.0, so for SBML documents, the above is the standard XML
 * declaration.
 *
 *
   */ public
 void writeXMLDecl() {
    libsbmlPINVOKE.XMLOutputStream_writeXMLDecl(swigCPtr);
  }


/**
   * Writes an XML comment with the name and version of this program.
   *
   * The XML comment has the following form:
   * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
   *
   * See the class constructor for more information about this program
   * comment.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @param writeTimestamp an optional flag indicating that a timestamp should
   * be written.
   */ public
 void writeComment(string programName, string programVersion, bool writeTimestamp) {
    libsbmlPINVOKE.XMLOutputStream_writeComment__SWIG_0(swigCPtr, programName, programVersion, writeTimestamp);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Writes an XML comment with the name and version of this program.
   *
   * The XML comment has the following form:
   * @verbatim
<!-- Created by <program name> version <program version>
on yyyy-MM-dd HH:mm with libSBML version <libsbml version>. -->
@endverbatim
   *
   * See the class constructor for more information about this program
   * comment.
   *
   * @param programName an optional program name to write as a comment
   * in the output stream.
   *
   * @param programVersion an optional version identification string to write
   * as a comment in the output stream.
   *
   * @param writeTimestamp an optional flag indicating that a timestamp should
   * be written.
   */ public
 void writeComment(string programName, string programVersion) {
    libsbmlPINVOKE.XMLOutputStream_writeComment__SWIG_1(swigCPtr, programName, programVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * Decreases the indentation level for this XMLOutputStream.
   *
   *
 * LibSBML tries to produce human-readable XML output by automatically
 * indenting the bodies of elements.  Callers can manually control
 * indentation further by using the XMLOutputStream::upIndent()
 * and XMLOutputStream::downIndent() methods to increase and
 * decrease, respectively, the current level of indentation in the
 * XML output.
   *
   * @see upIndent()
   */ public
 void downIndent() {
    libsbmlPINVOKE.XMLOutputStream_downIndent(swigCPtr);
  }


/**
   * Increases the indentation level for this XMLOutputStream.
   *
   *
 * LibSBML tries to produce human-readable XML output by automatically
 * indenting the bodies of elements.  Callers can manually control
 * indentation further by using the XMLOutputStream::upIndent()
 * and XMLOutputStream::downIndent() methods to increase and
 * decrease, respectively, the current level of indentation in the
 * XML output.
   *
   * @see downIndent()
   */ public
 void upIndent() {
    libsbmlPINVOKE.XMLOutputStream_upIndent(swigCPtr);
  }


/**
   * Returns the SBMLNamespaces object attached to this output stream.
   *
   * @return the SBMLNamespaces object, or @c null if none has been set.
   */ public
 SBMLNamespaces getSBMLNamespaces() {
	SBMLNamespaces ret
	    = (SBMLNamespaces) libsbml.DowncastSBMLNamespaces(libsbmlPINVOKE.XMLOutputStream_getSBMLNamespaces(swigCPtr), false);
	return ret;
}


/**
   * Sets the SBMLNamespaces object associated with this output stream.
   *
   * @param sbmlns the namespace object.
   */ public
 void setSBMLNamespaces(SBMLNamespaces sbmlns) {
    libsbmlPINVOKE.XMLOutputStream_setSBMLNamespaces(swigCPtr, SBMLNamespaces.getCPtr(sbmlns));
  }


/**
   * @return a boolean, whether the output stream will write an XML
   * comment at the top of the file. (Enabled by default.)
   */ public
 static bool getWriteComment() {
    bool ret = libsbmlPINVOKE.XMLOutputStream_getWriteComment();
    return ret;
  }


/**
   * sets a flag, whether the output stream will write an XML
   * comment at the top of the file. (Enabled by default.)
   *
   * @param writeComment the flag.
   */ public
 static void setWriteComment(bool writeComment) {
    libsbmlPINVOKE.XMLOutputStream_setWriteComment(writeComment);
  }


/**
   * @return a boolean, whether the output stream will write an XML
   * comment with a timestamp at the top of the file. (Enabled by default.)
   */ public
 static bool getWriteTimestamp() {
    bool ret = libsbmlPINVOKE.XMLOutputStream_getWriteTimestamp();
    return ret;
  }


/**
   * sets a flag, whether the output stream will write an XML
   * comment with a timestamp at the top of the file. (Enabled by default.)
   *
   * @param writeTimestamp the flag.
   */ public
 static void setWriteTimestamp(bool writeTimestamp) {
    libsbmlPINVOKE.XMLOutputStream_setWriteTimestamp(writeTimestamp);
  }


/**
   * @return the name of the library to be used in comments ('libSBML' by default).
   */ public
 static string getLibraryName() {
    string ret = libsbmlPINVOKE.XMLOutputStream_getLibraryName();
    return ret;
  }


/**
   * sets the name of the library writing the XML

   * @param libraryName the name of the library to be used in comments.
   */ public
 static void setLibraryName(string libraryName) {
    libsbmlPINVOKE.XMLOutputStream_setLibraryName(libraryName);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/**
   * @return a string representing the version of the library writing the output.
   *         This is the value of getLibSBMLDottedVersion() by default.
   */ public
 static string getLibraryVersion() {
    string ret = libsbmlPINVOKE.XMLOutputStream_getLibraryVersion();
    return ret;
  }


/**
   * sets the name of the library writing the output
   *
   * @param libraryVersion the version information as string.
   */ public
 static void setLibraryVersion(string libraryVersion) {
    libsbmlPINVOKE.XMLOutputStream_setLibraryVersion(libraryVersion);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }


/** */ /* libsbml-internal */ public
 long getIndent() { return (long)libsbmlPINVOKE.XMLOutputStream_getIndent(swigCPtr); }


/** */ /* libsbml-internal */ public
 void setIndent(long indent) {
    libsbmlPINVOKE.XMLOutputStream_setIndent(swigCPtr, indent);
  }

}

}
