/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  A node in libSBML's XML document tree.
 <p>
 * LibSBML implements an XML abstraction layer.  This layer presents a
 * uniform XML interface to calling programs regardless of which underlying
 * XML parser libSBML has actually been configured to use.  The basic data
 * object in the XML abstraction is a <em>node</em>, represented by {@link XMLNode}.
 <p>
 * An {@link XMLNode} can contain any number of children.  Each child is another
 * {@link XMLNode}, thereby forming a tree.  The methods {@link XMLNode#getNumChildren()}
 * and {@link XMLNode#getChild(long)} can be used to access the tree
 * structure starting from a given node.
 <p>
 * Each {@link XMLNode} is subclassed from {@link XMLToken}, and thus has the same methods
 * available as {@link XMLToken}.  These methods include {@link XMLToken#getNamespaces()},
 * {@link XMLToken#getPrefix()}, {@link XMLToken#getName()}, {@link XMLToken#getURI()}, and
 * {@link XMLToken#getAttributes()}.
 <p>
 * <h2>Conversion between an XML string and an {@link XMLNode}</h2>
 <p>
 * LibSBML provides the following utility functions for converting an XML
 * string (e.g., <code>&lt;annotation&gt;...&lt;/annotation&gt;</code>)
 * to/from an {@link XMLNode} object.
 <p>
 * <ul>
 * <li> {@link XMLNode#toXMLString()} returns a string representation of the {@link XMLNode}
 * object.
 <p>
 * <li> {@link XMLNode#convertXMLNodeToString(XMLNode)} (static
 * function) returns a string representation of the given {@link XMLNode} object.
 <p>
 * <li> {@link XMLNode#convertStringToXMLNode(String)} (static
 * function) returns an {@link XMLNode} object converted from the given XML string.
 *
 * </ul> <p>
 * The returned {@link XMLNode} object by {@link XMLNode#convertStringToXMLNode(String)} is a dummy root (container) {@link XMLNode} if the given XML string
 * has two or more top-level elements (e.g.,
 * &quot;<code>&lt;p&gt;...&lt;/p&gt;&lt;p&gt;...&lt;/p&gt;</code>&quot;). In
 * the dummy root node, each top-level element in the given XML string is
 * contained as a child {@link XMLNode}. {@link XMLToken#isEOF()} can be used to identify
 * if the returned {@link XMLNode} object is a dummy node or not.  Here is an
 * example:
<p>
<pre class='fragment'>
// Checks if the returned {@link XMLNode} object is a dummy root node:

String str = '...';
{@link XMLNode} xn = {@link XMLNode}.convertStringToXMLNode(str);
if ( xn == null )
{
  // returned value is null (error)
  ...
}
else if ( xn.isEOF() )
{
  // Root node is a dummy node.
  for ( int i = 0; i &lt; xn.getNumChildren(); i++ )
  {
    // access to each child node of the dummy node.
    {@link XMLNode} xnChild = xn.getChild(i);
    ...
  }
}
else
{
  // Root node is NOT a dummy node.
  ...
}
</pre>
*/

public class XMLNode extends XMLToken {
   private long swigCPtr;

   protected XMLNode(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.XMLNode_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(XMLNode obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (XMLNode obj)
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
        libsbmlJNI.delete_XMLNode(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }

  /**
   * Equality comparison method for XMLNode.
   * <p>
   * Because the Java methods for libSBML are actually wrappers around code
   * implemented in C++ and C, certain operations will not behave as
   * expected.  Equality comparison is one such case.  An instance of a
   * libSBML object class is actually a <em>proxy object</em>
   * wrapping the real underlying C/C++ object.  The normal <code>==</code>
   * equality operator in Java will <em>only compare the Java proxy objects</em>,
   * not the underlying native object.  The result is almost never what you
   * want in practical situations.  Unfortunately, Java does not provide a
   * way to override <code>==</code>.
   *  <p>
   * The alternative that must be followed is to use the
   * <code>equals()</code> method.  The <code>equals</code> method on this
   * class overrides the default java.lang.Object one, and performs an
   * intelligent comparison of instances of objects of this class.  The
   * result is an assessment of whether two libSBML Java objects are truly
   * the same underlying native-code objects.
   *  <p>
   * The use of this method in practice is the same as the use of any other
   * Java <code>equals</code> method.  For example,
   * <em>a</em><code>.equals(</code><em>b</em><code>)</code> returns
   * <code>true</code> if <em>a</em> and <em>b</em> are references to the
   * same underlying object.
   *
   * @param sb a reference to an object to which the current object
   * instance will be compared
   *
   * @return <code>true</code> if <code>sb</code> refers to the same underlying
   * native object as this one, <code>false</code> otherwise
   */
  public boolean equals(Object sb)
  {
    if ( this == sb )
    {
      return true;
    }
    return swigCPtr == getCPtr((XMLNode)(sb));
  }

  /**
   * Returns a hashcode for this XMLNode object.
   *
   * @return a hash code usable by Java methods that need them.
   */
  public int hashCode()
  {
    return (int)(swigCPtr^(swigCPtr>>>32));
  }


/**
   * Creates a new empty {@link XMLNode} with no children.
   */ public
 XMLNode() throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_0(), true);
  }


/**
   * Creates a new {@link XMLNode} by copying an {@link XMLToken} object.
   <p>
   * @param token {@link XMLToken} to be copied to {@link XMLNode}.
   */ public
 XMLNode(XMLToken token) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_1(XMLToken.getCPtr(token), token), true);
  }


/**
   * Creates a new start element {@link XMLNode} with the given set of attributes and
   * namespace declarations.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param namespaces {@link XMLNamespaces}, the namespaces to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes, XMLNamespaces namespaces, long line, long column) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_2(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes, XMLNamespaces.getCPtr(namespaces), namespaces, line, column), true);
  }


/**
   * Creates a new start element {@link XMLNode} with the given set of attributes and
   * namespace declarations.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param namespaces {@link XMLNamespaces}, the namespaces to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes, XMLNamespaces namespaces, long line) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_3(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes, XMLNamespaces.getCPtr(namespaces), namespaces, line), true);
  }


/**
   * Creates a new start element {@link XMLNode} with the given set of attributes and
   * namespace declarations.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param namespaces {@link XMLNamespaces}, the namespaces to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes, XMLNamespaces namespaces) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_4(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes, XMLNamespaces.getCPtr(namespaces), namespaces), true);
  }


/**
   * Creates a start element {@link XMLNode} with the given set of attributes.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

  */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes, long line, long column) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_5(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes, line, column), true);
  }


/**
   * Creates a start element {@link XMLNode} with the given set of attributes.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

  */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes, long line) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_6(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes, line), true);
  }


/**
   * Creates a start element {@link XMLNode} with the given set of attributes.
   <p>
   * @param triple {@link XMLTriple}.
   * @param attributes {@link XMLAttributes}, the attributes to set.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

  */ public
 XMLNode(XMLTriple triple, XMLAttributes attributes) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_7(XMLTriple.getCPtr(triple), triple, XMLAttributes.getCPtr(attributes), attributes), true);
  }


/**
   * Creates an end element {@link XMLNode}.
   <p>
   * @param triple {@link XMLTriple}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple, long line, long column) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_8(XMLTriple.getCPtr(triple), triple, line, column), true);
  }


/**
   * Creates an end element {@link XMLNode}.
   <p>
   * @param triple {@link XMLTriple}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple, long line) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_9(XMLTriple.getCPtr(triple), triple, line), true);
  }


/**
   * Creates an end element {@link XMLNode}.
   <p>
   * @param triple {@link XMLTriple}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(XMLTriple triple) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_10(XMLTriple.getCPtr(triple), triple), true);
  }


/**
   * Creates a text {@link XMLNode}.
   <p>
   * @param chars a string, the text to be added to the {@link XMLToken}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(String chars, long line, long column) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_11(chars, line, column), true);
  }


/**
   * Creates a text {@link XMLNode}.
   <p>
   * @param chars a string, the text to be added to the {@link XMLToken}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(String chars, long line) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_12(chars, line), true);
  }


/**
   * Creates a text {@link XMLNode}.
   <p>
   * @param chars a string, the text to be added to the {@link XMLToken}.
   * @param line a long integer, the line number (default = 0).
   * @param column a long integer, the column number (default = 0).
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 XMLNode(String chars) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_13(chars), true);
  }


/** * @internal */ public
 XMLNode(XMLInputStream stream) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_14(XMLInputStream.getCPtr(stream), stream), true);
  }


/**
   * Copy constructor; creates a copy of this {@link XMLNode}.
   <p>
   * @param orig the {@link XMLNode} instance to copy.
   */ public
 XMLNode(XMLNode orig) throws org.sbml.libsbml.XMLConstructorException {
    this(libsbmlJNI.new_XMLNode__SWIG_15(XMLNode.getCPtr(orig), orig), true);
  }


/**
   * Creates and returns a deep copy of this {@link XMLNode} object.
   <p>
   * @return the (deep) copy of this {@link XMLNode} object.
   */ public
 XMLNode cloneObject() {
    long cPtr = libsbmlJNI.XMLNode_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new XMLNode(cPtr, true);
  }


/**
   * Adds a copy of <code>node</code> as a child of this {@link XMLNode}.
   <p>
   * The given <code>node</code> is added at the end of the list of children.
   <p>
   * @param node the {@link XMLNode} to be added as child.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED}
   * <li> {@link libsbmlConstants#LIBSBML_INVALID_XML_OPERATION LIBSBML_INVALID_XML_OPERATION}
   *
   * </ul> <p>
   * @note The given node is added at the end of the children list.
   */ public
 int addChild(XMLNode node) {
    return libsbmlJNI.XMLNode_addChild(swigCPtr, this, XMLNode.getCPtr(node), node);
  }


/**
   * Inserts a copy of the given node as the <code>n</code>th child of this
   * {@link XMLNode}.
   <p>
   * If the given index <code>n</code> is out of range for this {@link XMLNode} instance,
   * the <code>node</code> is added at the end of the list of children.  Even in
   * that situation, this method does not throw an error.
   <p>
   * @param n an integer, the index at which the given node is inserted.
   * @param node an {@link XMLNode} to be inserted as <code>n</code>th child.
   <p>
   * @return a reference to the newly-inserted child <code>node</code>.
   */ public
 XMLNode insertChild(long n, XMLNode node) {
    return new XMLNode(libsbmlJNI.XMLNode_insertChild(swigCPtr, this, n, XMLNode.getCPtr(node), node), false);
  }


/**
   * Removes the <code>n</code>th child of this {@link XMLNode} and returns the
   * removed node.
   <p>
   * It is important to keep in mind that a given {@link XMLNode} may have more
   * than one child.  Calling this method erases all existing references to
   * child nodes <em>after</em> the given position <code>n</code>.  If the index <code>n</code> is
   * greater than the number of child nodes in this {@link XMLNode}, this method
   * takes no action (and returns <code>null</code>).
   <p>
   * @param n an integer, the index of the node to be removed.
   <p>
   * @return the removed child, or <code>null</code> if <code>n</code> is greater than the number
   * of children in this node.
   <p>
   * @note The caller owns the returned node and is responsible for deleting it.
   */ public
 XMLNode removeChild(long n) {
    long cPtr = libsbmlJNI.XMLNode_removeChild(swigCPtr, this, n);
    return (cPtr == 0) ? null : new XMLNode(cPtr, true);
  }


/**
   * Removes all children from this node.
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * </ul>
   */ public
 int removeChildren() {
    return libsbmlJNI.XMLNode_removeChildren(swigCPtr, this);
  }


/**
   * Returns the <code>n</code>th child of this {@link XMLNode}.
   <p>
   * If the index <code>n</code> is greater than the number of child nodes,
   * this method returns an empty node.
   <p>
   * @param n a long integereger, the index of the node to return.
   <p>
   * @return the <code>n</code>th child of this {@link XMLNode}.
   */ public
 XMLNode getChild(long n) {
    return new XMLNode(libsbmlJNI.XMLNode_getChild__SWIG_0(swigCPtr, this, n), false);
  }


/**
   * Returns the first child of this {@link XMLNode} with the corresponding name.
   <p>
   * If no child with corrsponding name can be found,
   * this method returns an empty node.
   <p>
   * @param name the name of the node to return.
   <p>
   * @return the first child of this {@link XMLNode} with given name.
   */ public
 XMLNode getChild(String name) {
    return new XMLNode(libsbmlJNI.XMLNode_getChild__SWIG_2(swigCPtr, this, name), false);
  }


/**
   * Return the index of the first child of this {@link XMLNode} with the given name.
   <p>
   * @param name a string, the name of the child for which the
   * index is required.
   <p>
   * @return the index of the first child of this {@link XMLNode} with the given
   * name, or -1 if not present.
   */ public
 int getIndex(String name) {
    return libsbmlJNI.XMLNode_getIndex(swigCPtr, this, name);
  }


/**
   * Return a boolean indicating whether this {@link XMLNode} has a child with the
   * given name.
   <p>
   * @param name a string, the name of the child to be checked.
   <p>
   * @return boolean indicating whether this {@link XMLNode} has a child with the
   * given name.
   */ public
 boolean hasChild(String name) {
    return libsbmlJNI.XMLNode_hasChild(swigCPtr, this, name);
  }


/**
   * Compare this {@link XMLNode} against another {@link XMLNode} returning true if both
   * nodes represent the same XML tree, or false otherwise.
   <p>
   * @param other another {@link XMLNode} to compare against.
   <p>
   * @param ignoreURI whether to ignore the namespace URI when doing the
   * comparison.
   <p>
   * @return boolean indicating whether this {@link XMLNode} represents the same XML
   * tree as another.
   */ public
 boolean xmlEquals(XMLNode other, boolean ignoreURI) {
    return libsbmlJNI.XMLNode_xmlEquals__SWIG_0(swigCPtr, this, XMLNode.getCPtr(other), other, ignoreURI);
  }


/**
   * Compare this {@link XMLNode} against another {@link XMLNode} returning true if both
   * nodes represent the same XML tree, or false otherwise.
   <p>
   * @param other another {@link XMLNode} to compare against.
   <p>
   * @param ignoreURI whether to ignore the namespace URI when doing the
   * comparison.
   <p>
   * @return boolean indicating whether this {@link XMLNode} represents the same XML
   * tree as another.
   */ public
 boolean xmlEquals(XMLNode other) {
    return libsbmlJNI.XMLNode_xmlEquals__SWIG_1(swigCPtr, this, XMLNode.getCPtr(other), other);
  }


/**
   * Returns the number of children for this {@link XMLNode}.
   <p>
   * @return the number of children for this {@link XMLNode}.
   */ public
 long getNumChildren() {
    return libsbmlJNI.XMLNode_getNumChildren(swigCPtr, this);
  }


/**
   * Returns a string representation of this {@link XMLNode}.
   <p>
   * @return a string derived from this {@link XMLNode}.
   */ public
 String toXMLString() {
    return libsbmlJNI.XMLNode_toXMLString(swigCPtr, this);
  }


/**
   * Returns a string representation of a given {@link XMLNode}.
   <p>
   * @param node the {@link XMLNode} to be represented as a string.
   <p>
   * @return a string-form representation of <code>node</code>.
   */ public
 static String convertXMLNodeToString(XMLNode node) {
    return libsbmlJNI.XMLNode_convertXMLNodeToString(XMLNode.getCPtr(node), node);
  }


/**
   * Returns an {@link XMLNode} which is derived from a string containing XML
   * content.
   <p>
   * The XML namespace must be defined using argument <code>xmlns</code> if the
   * corresponding XML namespace attribute is not part of the string of the
   * first argument.
   <p>
   * @param xmlstr string to be converted to a XML node.
   * @param xmlns {@link XMLNamespaces} the namespaces to set (default value is <code>null</code>).
   <p>
   * @note The caller owns the returned {@link XMLNode} and is reponsible for
   * deleting it.  The returned {@link XMLNode} object is a dummy root (container)
   * {@link XMLNode} if the top-level element in the given XML string is NOT
   * <code>&lt;html&gt;</code>, <code>&lt;body&gt;</code>,
   * <code>&lt;annotation&gt;</code>, or <code>&lt;notes&gt;</code>.  In
   * the dummy root node, each top-level element in the given XML string is
   * contained as a child {@link XMLNode}. {@link XMLToken#isEOF()} can be used to
   * identify if the returned {@link XMLNode} object is a dummy node.
   <p>
   * @return a {@link XMLNode} which is converted from string <code>xmlstr</code>.  If the
   * conversion failed, this method returns <code>null.</code>
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 static XMLNode convertStringToXMLNode(String xmlstr, XMLNamespaces xmlns) {
    long cPtr = libsbmlJNI.XMLNode_convertStringToXMLNode__SWIG_0(xmlstr, XMLNamespaces.getCPtr(xmlns), xmlns);
    return (cPtr == 0) ? null : new XMLNode(cPtr, true);
  }


/**
   * Returns an {@link XMLNode} which is derived from a string containing XML
   * content.
   <p>
   * The XML namespace must be defined using argument <code>xmlns</code> if the
   * corresponding XML namespace attribute is not part of the string of the
   * first argument.
   <p>
   * @param xmlstr string to be converted to a XML node.
   * @param xmlns {@link XMLNamespaces} the namespaces to set (default value is <code>null</code>).
   <p>
   * @note The caller owns the returned {@link XMLNode} and is reponsible for
   * deleting it.  The returned {@link XMLNode} object is a dummy root (container)
   * {@link XMLNode} if the top-level element in the given XML string is NOT
   * <code>&lt;html&gt;</code>, <code>&lt;body&gt;</code>,
   * <code>&lt;annotation&gt;</code>, or <code>&lt;notes&gt;</code>.  In
   * the dummy root node, each top-level element in the given XML string is
   * contained as a child {@link XMLNode}. {@link XMLToken#isEOF()} can be used to
   * identify if the returned {@link XMLNode} object is a dummy node.
   <p>
   * @return a {@link XMLNode} which is converted from string <code>xmlstr</code>.  If the
   * conversion failed, this method returns <code>null.</code>
   <p>
   *
</dl><dl class="docnote"><dt><b>Documentation note:</b></dt><dd>
The native C++ implementation of this method defines a default argument
value. In the documentation generated for different libSBML language
bindings, you may or may not see corresponding arguments in the method
declarations. For example, in Java and C#, a default argument is handled by
declaring two separate methods, with one of them having the argument and
the other one lacking the argument. However, the libSBML documentation will
be <em>identical</em> for both methods. Consequently, if you are reading
this and do not see an argument even though one is described, please look
for descriptions of other variants of this method near where this one
appears in the documentation.
</dd></dl>

   */ public
 static XMLNode convertStringToXMLNode(String xmlstr) {
    long cPtr = libsbmlJNI.XMLNode_convertStringToXMLNode__SWIG_1(xmlstr);
    return (cPtr == 0) ? null : new XMLNode(cPtr, true);
  }

}
