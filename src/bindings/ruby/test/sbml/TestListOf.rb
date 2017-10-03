# @file    TestListOf.rb
# @brief   ListOf unit tests
#
# @author  Akiya Jouraku (Ruby conversion)
# @author  Ben Bornstein
#
#
# ====== WARNING ===== WARNING ===== WARNING ===== WARNING ===== WARNING ======
#
# DO NOT EDIT THIS FILE.
#
# This file was generated automatically by converting the file located at
# src/sbml/test/TestListOf.c
# using the conversion program dev/utilities/translateTests/translateTests.pl.
# Any changes made here will be lost the next time the file is regenerated.
#
# -----------------------------------------------------------------------------
# This file is part of libSBML.  Please visit http://sbml.org for more
# information about SBML, and the latest version of libSBML.
#
# Copyright 2005-2010 California Institute of Technology.
# Copyright 2002-2005 California Institute of Technology and
#                     Japan Science and Technology Corporation.
#
# This library is free software; you can redistribute it and/or modify it
# under the terms of the GNU Lesser General Public License as published by
# the Free Software Foundation.  A copy of the license agreement is provided
# in the file named "LICENSE.txt" included with this software distribution
# and also available online as http://sbml.org/software/libsbml/license.html
# -----------------------------------------------------------------------------
require 'test/unit'
require 'libSBML'

class TestListOf < Test::Unit::TestCase

  def test_ListOf_append
    m = LibSBML::Model.new(2,4)
    m.createCompartment()
    loc = m.getListOfCompartments()
    assert( loc.size() == 1 )
    c = LibSBML::Compartment.new(2,4)
    i = loc.append(c)
    assert( i == LibSBML::LIBSBML_OPERATION_SUCCESS )
    assert( loc.size() == 2 )
    sp = LibSBML::Species.new(2,4)
    i = loc.append(sp)
    assert( i == LibSBML::LIBSBML_INVALID_OBJECT )
    assert( loc.size() == 2 )
    m = nil
    sp = nil
  end

  def test_ListOf_clear
    lo = LibSBML::ListOf.new()
    sp = LibSBML::Species.new(2,4)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    assert( lo.size() == 5 )
    lo.clear(true)
    assert( lo.size() == 0 )
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.appendAndOwn(sp)
    assert( lo.size() == 5 )
    elem = lo.get(0)
    elem = nil
    elem = lo.get(1)
    elem = nil
    elem = lo.get(2)
    elem = nil
    elem = lo.get(3)
    elem = nil
    elem = lo.get(4)
    elem = nil
    lo.clear(false)
    assert( lo.size() == 0 )
    lo = nil
  end

  def test_ListOf_create
    lo = LibSBML::ListOf.new()
    assert( lo.getTypeCode() == LibSBML::SBML_LIST_OF )
    assert( lo.getNotes() == nil )
    assert( lo.getAnnotation() == nil )
    assert( lo.getMetaId() == "" )
    assert( lo.size() == 0 )
    lo = nil
  end

  def test_ListOf_free_NULL
  end

  def test_ListOf_get
    lo = LibSBML::ListOf.new()
    assert( lo.size() == 0 )
    sp = LibSBML::Species.new(2,4)
    lo.append(sp)
    assert( lo.size() == 1 )
    elem = lo.get(1)
    assert( sp != elem )
    sp = nil
    lo = nil
  end

  def test_ListOf_remove
    lo = LibSBML::ListOf.new()
    sp = LibSBML::Species.new(2,4)
    assert( lo.size() == 0 )
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    assert( lo.size() == 5 )
    elem = lo.remove(0)
    elem = nil
    elem = lo.remove(0)
    elem = nil
    elem = lo.remove(0)
    elem = nil
    elem = lo.remove(0)
    elem = nil
    elem = lo.remove(0)
    elem = nil
    assert( lo.size() == 0 )
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.append(sp)
    lo.appendAndOwn(sp)
    assert( lo.size() == 5 )
    lo = nil
  end

end