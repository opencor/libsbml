/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  A list of {@link Event} objects.
 <p>
 * <p>
 * The various ListOf___ classes in SBML
 * are merely containers used for organizing the main components of an SBML
 * model.  In libSBML's implementation, ListOf___
 * classes are derived from the
 * intermediate utility class {@link ListOf}, which
 * is not defined by the SBML specifications but serves as a useful
 * programmatic construct.  {@link ListOf} is itself is in turn derived from {@link SBase},
 * which provides all of the various ListOf___
 * classes with common features
 * defined by the SBML specification, such as 'metaid' attributes and
 * annotations.
 <p>
 * The relationship between the lists and the rest of an SBML model is
 * illustrated by the following (for SBML Level&nbsp;2 Version&nbsp;4):
 <p>
 * <figure>
  <object type="image/svg+xml" data="listof-illustration.svg" class="centered"></object>
</figure>

 <p>
 * SBML Level&nbsp;3 Version&nbsp;1 has essentially the same structure as
 * Level&nbsp;2 Version&nbsp;4, depicted above, but SBML Level&nbsp;3
 * Version&nbsp;2 allows
 * containers to contain zero or more of the relevant object, instead of
 * requiring at least one.  As such, libsbml will write out an
 * otherwise-empty ListOf___ element that has any optional attribute set
 * (such as 'id' or 'metaid'), that has an optional child (such
 * as a 'notes' or 'annotation'), or that has attributes or children set
 * from any SBML Level&nbsp;3 package, whether or not the ListOf___ has
 * any other children.
 <p>
 * Readers may wonder about the motivations for using the ListOf___
 * containers in SBML.  A simpler approach in XML might be to place the
 * components all directly at the top level of the model definition.  The
 * choice made in SBML is to group them within XML elements named after
 * ListOf<em>Classname</em>, in part because it helps organize the
 * components.  More importantly, the fact that the container classes are
 * derived from {@link SBase} means that software tools can add information <em>about</em>
 * the lists themselves into each list container's 'annotation'.
 <p>
 * @see ListOfFunctionDefinitions
 * @see ListOfUnitDefinitions
 * @see ListOfCompartmentTypes
 * @see ListOfSpeciesTypes
 * @see ListOfCompartments
 * @see ListOfSpecies
 * @see ListOfParameters
 * @see ListOfInitialAssignments
 * @see ListOfRules
 * @see ListOfConstraints
 * @see ListOfReactions
 * @see ListOfEvents
 */

public class ListOfEvents extends ListOf {
   private long swigCPtr;

   protected ListOfEvents(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.ListOfEvents_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(ListOfEvents obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (ListOfEvents obj)
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
        libsbmlJNI.delete_ListOfEvents(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }


/**
   * Creates a new {@link ListOfEvents} object.
   <p>
   * The object is constructed such that it is valid for the given SBML
   * Level and Version combination.
   <p>
   * @param level the SBML Level.
   <p>
   * @param version the Version within the SBML Level.
   <p>
   * <p>
 * @throws SBMLConstructorException
 * Thrown if the given <code>level</code> and <code>version</code> combination are invalid
 * or if this object is incompatible with the given level and version.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   */ public
 ListOfEvents(long level, long version) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_ListOfEvents__SWIG_0(level, version), true);
  }


/**
   * Creates a new {@link ListOfEvents} object.
   <p>
   * The object is constructed such that it is valid for the SBML Level and
   * Version combination determined by the {@link SBMLNamespaces} object in
   * <code>sbmlns</code>.
   <p>
   * @param sbmlns an {@link SBMLNamespaces} object that is used to determine the
   * characteristics of the {@link ListOfEvents} object to be created.
   <p>
   * <p>
 * @throws SBMLConstructorException
 * Thrown if the given <code>sbmlns</code> is inconsistent or incompatible
 * with this object.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   */ public
 ListOfEvents(SBMLNamespaces sbmlns) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_ListOfEvents__SWIG_1(SBMLNamespaces.getCPtr(sbmlns), sbmlns), true);
  }


/**
   * Creates and returns a deep copy of this {@link ListOfEvents} object.
   <p>
   * @return the (deep) copy of this {@link ListOfEvents} object.
   */ public
 ListOfEvents cloneObject() {
    long cPtr = libsbmlJNI.ListOfEvents_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new ListOfEvents(cPtr, true);
  }


/**
   * Returns the libSBML type code for the objects contained in this {@link ListOf}
   * (i.e., {@link Event} objects, if the list is non-empty).
   <p>
   * <p>
 * LibSBML attaches an identifying code to every kind of SBML object.  These
 * are integer constants known as <em>SBML type codes</em>.  The names of all
 * the codes begin with the characters <code>SBML_</code>.
 * In the Java language interface for libSBML, the
 * type codes are defined as static integer constants in the interface class
 * {@link libsbmlConstants}.    Note that different Level&nbsp;3
 * package plug-ins may use overlapping type codes; to identify the package
 * to which a given object belongs, call the
 * <code>{@link SBase#getPackageName()}
 * </code>
 * method on the object.
   <p>
   * @return the SBML type code for the objects contained in this ListOf:
   * {@link libsbmlConstants#SBML_EVENT SBML_EVENT} (default).
   <p>
   * @see #getElementName()
   * @see #getPackageName()
   */ public
 int getItemTypeCode() {
    return libsbmlJNI.ListOfEvents_getItemTypeCode(swigCPtr, this);
  }


/**
   * Returns the XML element name of this object.
   <p>
   * For {@link ListOfEvents}, the XML element name is <code>'listOfEvents'.</code>
   <p>
   * @return the name of this element, i.e., <code>'listOfEvents'.</code>
   */ public
 String getElementName() {
    return libsbmlJNI.ListOfEvents_getElementName(swigCPtr, this);
  }


/**
   * Get an {@link Event} from the {@link ListOfEvents}.
   <p>
   * @param n the index number of the {@link Event} to get.
   <p>
   * @return the <code>n</code>th {@link Event} in this {@link ListOfEvents}.
   <p>
   * @see #size()
   */ public
 Event get(long n) {
    long cPtr = libsbmlJNI.ListOfEvents_get__SWIG_0(swigCPtr, this, n);
    return (cPtr == 0) ? null : new Event(cPtr, false);
  }


/**
   * Get an {@link Event} from the {@link ListOfEvents}
   * based on its identifier.
   <p>
   * @param sid a string representing the identifier
   * of the {@link Event} to get.
   <p>
   * @return {@link Event} in this {@link ListOfEvents}
   * with the given <code>sid</code> or <code>null</code> if no such
   * {@link Event} exists.
   <p>
   * @see #get(long n)
   * @see #size()
   */ public
 Event get(String sid) {
    long cPtr = libsbmlJNI.ListOfEvents_get__SWIG_2(swigCPtr, this, sid);
    return (cPtr == 0) ? null : new Event(cPtr, false);
  }


/**
   * Removes the nth item from this {@link ListOfEvents} items and returns a pointer to
   * it.
   <p>
   * The caller owns the returned item and is responsible for deleting it.
   <p>
   * @param n the index of the item to remove.
   <p>
   * @see #size()
   */ public
 Event remove(long n) {
    long cPtr = libsbmlJNI.ListOfEvents_remove__SWIG_0(swigCPtr, this, n);
    return (cPtr == 0) ? null : new Event(cPtr, true);
  }


/**
   * Removes item in this {@link ListOfEvents} items with the given identifier.
   <p>
   * The caller owns the returned item and is responsible for deleting it.
   * If none of the items in this list have the identifier <code>sid</code>, then
   * <code>null</code> is returned.
   <p>
   * @param sid the identifier of the item to remove.
   <p>
   * @return the item removed.  As mentioned above, the caller owns the
   * returned item.
   */ public
 Event remove(String sid) {
    long cPtr = libsbmlJNI.ListOfEvents_remove__SWIG_1(swigCPtr, this, sid);
    return (cPtr == 0) ? null : new Event(cPtr, true);
  }

}
