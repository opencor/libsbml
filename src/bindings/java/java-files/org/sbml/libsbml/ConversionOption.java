/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  A single configuration setting for an SBML converter.
 <p>
 * <p style='color: #777; font-style: italic'>
This class of objects is defined by libSBML only and has no direct
equivalent in terms of SBML components.  It is a class used in
the implementation of extra functionality provided by libSBML.
</p>

 <p>
 * LibSBML provides a number of converters that can perform transformations
 * on SBML documents.  These converters allow their behaviors to be
 * controlled by setting property values.  Converter properties are
 * communicated using objects of class {@link ConversionProperties}, and within
 * such objects, individual options are encapsulated using {@link ConversionOption}
 * objects.
 <p>
 * A {@link ConversionOption} object consists of
 * four parts:
 * <ul>
 * <li> A <em>key</em>, acting as the name of the option.
 * <li> A <em>value</em> of this option.
 * <li> A <em>type</em> for the value; the type code is chosen from a set of integer constants whose names all
 * begin with the prefix <code>CNV_TYPE_</code>.  (See the separate <a
 * class='el' href='#ConversionOptionType_t'>subsection</a> below for more
 * information.)
 * <li> A <em>description</em> consisting of a text string that describes the
 * option in some way.
 *
 * </ul> <p>
 * There are no constraints on the values of keys or descriptions;
 * authors of SBML converters are free to choose them as they see fit.
 <p>
 * <h2>Conversion option data types</h2>
 <p>
 * An option in {@link ConversionOption} must have a data type declared, to
 * indicate whether it is a string value, an integer, and so forth.  The
 * possible types of values are taken from
 * a set of
 * constants whose symbol names begin with the prefix
 * <code>CNV_TYPE_</code>. The following are the possible values:
 <p>
 * <center>
 * <table width='90%' cellspacing='1' cellpadding='1' border='0' class='normal-font'>
 *  <tr style='background: lightgray' class='normal-font'>
 *      <td><strong>Enumerator</strong></td>
 *      <td><strong>Meaning</strong></td>
 *  </tr>
 * <tr>
 * <td><code>{@link libsbmlConstants#CNV_TYPE_BOOL CNV_TYPE_BOOL}</code></td>
 * <td>Indicates the value type is a Boolean.</td>
 * </tr>
 * <tr>
 * <td><code>{@link libsbmlConstants#CNV_TYPE_DOUBLE CNV_TYPE_DOUBLE}</code></td>
 * <td>Indicates the value type is a double-sized float.</td>
 * </tr>
 * <tr>
 * <td><code>{@link libsbmlConstants#CNV_TYPE_INT CNV_TYPE_INT}</code></td>
 * <td>Indicates the value type is an integer.</td>
 * </tr>
 * <tr>
 * <td><code>{@link libsbmlConstants#CNV_TYPE_SINGLE CNV_TYPE_SINGLE}</code></td>
 * <td>Indicates the value type is a float.</td>
 * </tr>
 * <tr>
  * <td><code>{@link libsbmlConstants#CNV_TYPE_STRING CNV_TYPE_STRING}</code></td>
 * <td>Indicates the value type is a string.</td>
 * </tr>
 * </table>
 * </center>
 <p>
 * @see ConversionProperties
 */

public class ConversionOption {
   private long swigCPtr;
   protected boolean swigCMemOwn;

   protected ConversionOption(long cPtr, boolean cMemoryOwn)
   {
     swigCMemOwn = cMemoryOwn;
     swigCPtr    = cPtr;
   }

   protected static long getCPtr(ConversionOption obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (ConversionOption obj)
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
        libsbmlJNI.delete_ConversionOption(swigCPtr);
      }
      swigCPtr = 0;
    }
  }


/**
   * Creates a new {@link ConversionOption}.
   <p>
   * This is the general constructor, taking arguments for all aspects of
   * an option.  Other constructors exist with different arguments.
   <p>
   * <p>
 * The conversion <code>type</code> argument value must be one of
 * the constants whose names begin
 * with the characters <code>CNV_TYPE_</code> in the interface class
 * {@link libsbmlConstants}.
   <p>
   * @param key the key for this option.
   * @param value an optional value for this option.
   * @param type the type of this option.
   * @param description the description for this option.
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
 ConversionOption(String key, String value, int type, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_0(key, value, type, description), true);
  }


/**
   * Creates a new {@link ConversionOption}.
   <p>
   * This is the general constructor, taking arguments for all aspects of
   * an option.  Other constructors exist with different arguments.
   <p>
   * <p>
 * The conversion <code>type</code> argument value must be one of
 * the constants whose names begin
 * with the characters <code>CNV_TYPE_</code> in the interface class
 * {@link libsbmlConstants}.
   <p>
   * @param key the key for this option.
   * @param value an optional value for this option.
   * @param type the type of this option.
   * @param description the description for this option.
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
 ConversionOption(String key, String value, int type) {
    this(libsbmlJNI.new_ConversionOption__SWIG_1(key, value, type), true);
  }


/**
   * Creates a new {@link ConversionOption}.
   <p>
   * This is the general constructor, taking arguments for all aspects of
   * an option.  Other constructors exist with different arguments.
   <p>
   * <p>
 * The conversion <code>type</code> argument value must be one of
 * the constants whose names begin
 * with the characters <code>CNV_TYPE_</code> in the interface class
 * {@link libsbmlConstants}.
   <p>
   * @param key the key for this option.
   * @param value an optional value for this option.
   * @param type the type of this option.
   * @param description the description for this option.
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
 ConversionOption(String key, String value) {
    this(libsbmlJNI.new_ConversionOption__SWIG_2(key, value), true);
  }


/**
   * Creates a new {@link ConversionOption}.
   <p>
   * This is the general constructor, taking arguments for all aspects of
   * an option.  Other constructors exist with different arguments.
   <p>
   * <p>
 * The conversion <code>type</code> argument value must be one of
 * the constants whose names begin
 * with the characters <code>CNV_TYPE_</code> in the interface class
 * {@link libsbmlConstants}.
   <p>
   * @param key the key for this option.
   * @param value an optional value for this option.
   * @param type the type of this option.
   * @param description the description for this option.
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
 ConversionOption(String key) {
    this(libsbmlJNI.new_ConversionOption__SWIG_3(key), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for string-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, String value, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_4(key, value, description), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for Boolean-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, boolean value, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_6(key, value, description), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for Boolean-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, boolean value) {
    this(libsbmlJNI.new_ConversionOption__SWIG_7(key, value), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for double-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, double value, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_8(key, value, description), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for double-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, double value) {
    this(libsbmlJNI.new_ConversionOption__SWIG_9(key, value), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for float-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, float value, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_10(key, value, description), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for float-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, float value) {
    this(libsbmlJNI.new_ConversionOption__SWIG_11(key, value), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for integer-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, int value, String description) {
    this(libsbmlJNI.new_ConversionOption__SWIG_12(key, value, description), true);
  }


/**
   * Creates a new {@link ConversionOption} specialized for integer-type options.
   <p>
   * @param key the key for this option.
   * @param value the value for this option.
   * @param description an optional description.
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
 ConversionOption(String key, int value) {
    this(libsbmlJNI.new_ConversionOption__SWIG_13(key, value), true);
  }


/**
   * Copy constructor; creates a copy of an {@link ConversionOption} object.
   <p>
   * @param orig the {@link ConversionOption} object to copy.
   */ public
 ConversionOption(ConversionOption orig) {
    this(libsbmlJNI.new_ConversionOption__SWIG_14(ConversionOption.getCPtr(orig), orig), true);
  }


/**
   * Creates and returns a deep copy of this {@link ConversionOption} object.
   <p>
   * @return the (deep) copy of this {@link ConversionOption} object.
   */ public
 ConversionOption cloneObject() {
    long cPtr = libsbmlJNI.ConversionOption_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new ConversionOption(cPtr, true);
  }


/**
   * Returns the key for this option.
   <p>
   * @return the key, as a string.
   */ public
 String getKey() {
    return libsbmlJNI.ConversionOption_getKey(swigCPtr, this);
  }


/**
   * Sets the key for this option.
   <p>
   * @param key a string representing the key to set.
   */ public
 void setKey(String key) {
    libsbmlJNI.ConversionOption_setKey(swigCPtr, this, key);
  }


/**
   * Returns the value of this option.
   <p>
   * @return the value of this option, as a string.
   */ public
 String getValue() {
    return libsbmlJNI.ConversionOption_getValue(swigCPtr, this);
  }


/**
   * Sets the value for this option.
   <p>
   * @param value the value to set, as a string.
   */ public
 void setValue(String value) {
    libsbmlJNI.ConversionOption_setValue(swigCPtr, this, value);
  }


/**
   * Returns the description string for this option.
   <p>
   * @return the description of this option.
   */ public
 String getDescription() {
    return libsbmlJNI.ConversionOption_getDescription(swigCPtr, this);
  }


/**
   * Sets the description text for this option.
   <p>
   * @param description the description to set for this option.
   */ public
 void setDescription(String description) {
    libsbmlJNI.ConversionOption_setDescription(swigCPtr, this, description);
  }


/**
   * Returns the type of this option
   <p>
   * @return the type of this option.
   */ public
 int getType() {
    return libsbmlJNI.ConversionOption_getType(swigCPtr, this);
  }


/**
   * Sets the type of this option.
   <p>
   * <p>
 * The conversion <code>type</code> argument value must be one of
 * the constants whose names begin
 * with the characters <code>CNV_TYPE_</code> in the interface class
 * {@link libsbmlConstants}.
   <p>
   * @param type the type value to use.
   */ public
 void setType(int type) {
    libsbmlJNI.ConversionOption_setType(swigCPtr, this, type);
  }


/**
   * Returns the value of this option as a Boolean.
   <p>
   * @return the value of this option.
   */ public
 boolean getBoolValue() {
    return libsbmlJNI.ConversionOption_getBoolValue(swigCPtr, this);
  }


/**
   * Set the value of this option to a given Boolean value.
   <p>
   * Invoking this method will also set the type of the option to
   * {@link libsbmlConstants#CNV_TYPE_BOOL CNV_TYPE_BOOL}.
   <p>
   * @param value the Boolean value to set.
   */ public
 void setBoolValue(boolean value) {
    libsbmlJNI.ConversionOption_setBoolValue(swigCPtr, this, value);
  }


/**
   * Returns the value of this option as a <code>double.</code>
   <p>
   * @return the value of this option.
   */ public
 double getDoubleValue() {
    return libsbmlJNI.ConversionOption_getDoubleValue(swigCPtr, this);
  }


/**
   * Set the value of this option to a given <code>double</code> value.
   <p>
   * Invoking this method will also set the type of the option to
   * {@link libsbmlConstants#CNV_TYPE_DOUBLE CNV_TYPE_DOUBLE}.
   <p>
   * @param value the value to set.
   */ public
 void setDoubleValue(double value) {
    libsbmlJNI.ConversionOption_setDoubleValue(swigCPtr, this, value);
  }


/**
   * Returns the value of this option as a <code>float.</code>
   <p>
   * @return the value of this option as a float.
   */ public
 float getFloatValue() {
    return libsbmlJNI.ConversionOption_getFloatValue(swigCPtr, this);
  }


/**
   * Set the value of this option to a given <code>float</code> value.
   <p>
   * Invoking this method will also set the type of the option to
   * {@link libsbmlConstants#CNV_TYPE_SINGLE CNV_TYPE_SINGLE}.
   <p>
   * @param value the value to set.
   */ public
 void setFloatValue(float value) {
    libsbmlJNI.ConversionOption_setFloatValue(swigCPtr, this, value);
  }


/**
   * Returns the value of this option as an <code>integer.</code>
   <p>
   * @return the value of this option, as an int.
   */ public
 int getIntValue() {
    return libsbmlJNI.ConversionOption_getIntValue(swigCPtr, this);
  }


/**
   * Set the value of this option to a given <code>int</code> value.
   <p>
   * Invoking this method will also set the type of the option to
   * {@link libsbmlConstants#CNV_TYPE_INT CNV_TYPE_INT}.
   <p>
   * @param value the value to set.
   */ public
 void setIntValue(int value) {
    libsbmlJNI.ConversionOption_setIntValue(swigCPtr, this, value);
  }

}
