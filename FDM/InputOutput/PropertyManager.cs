﻿
//namespace FDM.InputOutput
//{

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

// Header:       FGPropertyManager.h
// Author:       Tony Peden
//               Based on work originally by David Megginson
// Date:         2/2002

// ------------- Copyright (C) 2002 -------------

// This program is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free Software
// Foundation; either version 2 of the License, or (at your option) any later
// version.

// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public License for more
// details.

// You should have received a copy of the GNU Lesser General Public License along with
// this program; if not, write to the Free Software Foundation, Inc., 59 Temple
// Place - Suite 330, Boston, MA  02111-1307, USA.

// Further information about the GNU Lesser General Public License can also be found on
// the world wide web at http://www.gnu.org.

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//SENTRY
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//#ifndef FGPROPERTYMANAGER_H
//#define FGPROPERTYMANAGER_H

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//INCLUDES
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//// This is needed by MSVC9 when included in FlightGear because of
//// the new Vec4d class in props.hxx
//#if defined( HAVE_CONFIG_H )
//# include <config.h>
//#endif

//#include <string>
//#include "simgear/props/props.hxx"
//#if !PROPS_STANDALONE
//# include "simgear/math/SGMath.hxx"
//#endif

//#include "FGJSBBase.h"

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//DEFINITIONS
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//#define ID_PROPERTYMANAGER "$Id: FGPropertyManager.h,v 1.28 2013/09/28 14:43:15 bcoconni Exp $"

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//FORWARD DECLARATIONS
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//namespace JSBSim {

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//CLASS DOCUMENTATION
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

///** Class wrapper for property handling.
//    @author David Megginson, Tony Peden
//  */

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//CLASS DECLARATION
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//class FGPropertyNode : public SGPropertyNode
//{
//  public:
//    /// Destructor
//    virtual ~FGPropertyNode(void) {}

//    /**
//     * Get a property node.
//     *
//     * @param path The path of the node, relative to root.
//     * @param create true to create the node if it doesn't exist.
//     * @return The node, or 0 if none exists and none was created.
//     */
//    FGPropertyNode*
//    GetNode (const std::string &path, bool create = false);

//    FGPropertyNode*
//    GetNode (const std::string &relpath, int index, bool create = false);

//    /**
//     * Test whether a given node exists.
//     *
//     * @param path The path of the node, relative to root.
//     * @return true if the node exists, false otherwise.
//     */
//    bool HasNode (const std::string &path);

//    /**
//     * Get the name of a node
//     */
//    std::string GetName( void ) const;

//    /**
//     * Get the name of a node without underscores, etc.
//     */
//    std::string GetPrintableName( void ) const;

//    /**
//     * Get the fully qualified name of a node
//     * This function is very slow, so is probably useful for debugging only.
//     */
//    std::string GetFullyQualifiedName(void) const;

//    /**
//     * Get the qualified name of a node relative to given base path,
//     * otherwise the fully qualified name.
//     * This function is very slow, so is probably useful for debugging only.
//     *
//     * @param path The path to strip off, if found.
//     */
//    std::string GetRelativeName( const std::string &path = "/fdm/jsbsim/" ) const;

//    /**
//     * Get a bool value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getBoolValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as a bool, or the default value provided.
//     */
//    bool GetBool (const std::string &name, bool defaultValue = false) const;


//    /**
//     * Get an int value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getIntValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as an int, or the default value provided.
//     */
//    int GetInt (const std::string &name, int defaultValue = 0) const;


//    /**
//     * Get a long value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getLongValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as a long, or the default value provided.
//     */
//    int GetLong (const std::string &name, long defaultValue = 0L) const;


//    /**
//     * Get a float value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getFloatValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as a float, or the default value provided.
//     */
//    float GetFloat (const std::string &name, float defaultValue = 0.0) const;


//    /**
//     * Get a double value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getDoubleValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as a double, or the default value provided.
//     */
//    double GetDouble (const std::string &name, double defaultValue = 0.0) const;


//    /**
//     * Get a string value for a property.
//     *
//     * This method is convenient but inefficient.  It should be used
//     * infrequently (i.e. for initializing, loading, saving, etc.),
//     * not in the main loop.  If you need to get a value frequently,
//     * it is better to look up the node itself using GetNode and then
//     * use the node's getStringValue() method, to avoid the lookup overhead.
//     *
//     * @param name The property name.
//     * @param defaultValue The default value to return if the property
//     *        does not exist.
//     * @return The property's value as a string, or the default value provided.
//     */
//    std::string GetString (const std::string &name, std::string defaultValue = "") const;


//    /**
//     * Set a bool value for a property.
//     *
//     * Assign a bool value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * BOOL; if it has a type of UNKNOWN, the type will also be set to
//     * BOOL; otherwise, the bool value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetBool (const std::string &name, bool val);


//    /**
//     * Set an int value for a property.
//     *
//     * Assign an int value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * INT; if it has a type of UNKNOWN, the type will also be set to
//     * INT; otherwise, the bool value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetInt (const std::string &name, int val);


//    /**
//     * Set a long value for a property.
//     *
//     * Assign a long value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * LONG; if it has a type of UNKNOWN, the type will also be set to
//     * LONG; otherwise, the bool value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetLong (const std::string &name, long val);


//    /**
//     * Set a float value for a property.
//     *
//     * Assign a float value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * FLOAT; if it has a type of UNKNOWN, the type will also be set to
//     * FLOAT; otherwise, the bool value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetFloat (const std::string &name, float val);


//    /**
//     * Set a double value for a property.
//     *
//     * Assign a double value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * DOUBLE; if it has a type of UNKNOWN, the type will also be set to
//     * DOUBLE; otherwise, the double value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetDouble (const std::string &name, double val);


//    /**
//     * Set a string value for a property.
//     *
//     * Assign a string value to a property.  If the property does not
//     * yet exist, it will be created and its type will be set to
//     * STRING; if it has a type of UNKNOWN, the type will also be set to
//     * STRING; otherwise, the string value will be converted to the property's
//     * type.
//     *
//     * @param name The property name.
//     * @param val The new value for the property.
//     * @return true if the assignment succeeded, false otherwise.
//     */
//    bool SetString (const std::string &name, const std::string &val);


//    ////////////////////////////////////////////////////////////////////////
//    // Convenience functions for setting property attributes.
//    ////////////////////////////////////////////////////////////////////////


//    /**
//     * Set the state of the archive attribute for a property.
//     *
//     * If the archive attribute is true, the property will be written
//     * when a flight is saved; if it is false, the property will be
//     * skipped.
//     *
//     * A warning message will be printed if the property does not exist.
//     *
//     * @param name The property name.
//     * @param state The state of the archive attribute (defaults to true).
//     */
//    void SetArchivable (const std::string &name, bool state = true);


//    /**
//     * Set the state of the read attribute for a property.
//     *
//     * If the read attribute is true, the property value will be readable;
//     * if it is false, the property value will always be the default value
//     * for its type.
//     *
//     * A warning message will be printed if the property does not exist.
//     *
//     * @param name The property name.
//     * @param state The state of the read attribute (defaults to true).
//     */
//    void SetReadable (const std::string &name, bool state = true);


//    /**
//     * Set the state of the write attribute for a property.
//     *
//     * If the write attribute is true, the property value may be modified
//     * (depending on how it is tied); if the write attribute is false, the
//     * property value may not be modified.
//     *
//     * A warning message will be printed if the property does not exist.
//     *
//     * @param name The property name.
//     * @param state The state of the write attribute (defaults to true).
//     */
//    void SetWritable (const std::string &name, bool state = true);
//};

//typedef SGSharedPtr<FGPropertyNode> FGPropertyNode_ptr;
//typedef SGSharedPtr<const FGPropertyNode> FGConstPropertyNode_ptr;

//class FGPropertyManager
//{
//  public:
//    /// Default constructor
//    FGPropertyManager(void) { root = new FGPropertyNode; }

//    /// Constructor
//    FGPropertyManager(FGPropertyNode* _root) : root(_root) {};

//    /// Destructor
//    virtual ~FGPropertyManager(void) { Unbind(); }

//    FGPropertyNode* GetNode(void) const { return root; }
//    FGPropertyNode* GetNode(const std::string &path, bool create = false)
//    { return root->GetNode(path, create); }
//    FGPropertyNode* GetNode(const std::string &relpath, int index, bool create = false)
//    { return root->GetNode(relpath, index, create); }
//    bool HasNode(const std::string& path) const
//    {
//      std::string newPath = path;
//      if (newPath[0] == '-') newPath.erase(0,1);
//      return root->HasNode(newPath);
//    }

//    /** Property-ify a name
//     *  replaces spaces with '-' and, optionally, makes name all lower case
//     *  @param name string to change
//     *  @param lowercase true to change all upper case chars to lower
//     *  NOTE: this function changes its argument and thus relies
//     *  on pass by value
//     */
//    std::string mkPropertyName(std::string name, bool lowercase);

//    ////////////////////////////////////////////////////////////////////////
//    // Convenience functions for tying properties, with logging.
//    ////////////////////////////////////////////////////////////////////////


//    /**
//     * Untie a property from an external data source.
//     *
//     * Classes should use this function to release control of any
//     * properties they are managing.
//     */
//    void Untie (const std::string &name);

//    /**
//     * Unbind all properties bound by this manager to an external data source.
//     *
//     * Classes should use this function to release control of any
//     * properties they have bound using this property manager.
//     */
//    void Unbind (void);

//        // Templates cause ambiguity here

//    /**
//     * Tie a property to an external bool variable.
//     *
//     * The property's value will automatically mirror the variable's
//     * value, and vice-versa, until the property is untied.
//     *
//     * @param name The property name to tie (full path).
//     * @param pointer A pointer to the variable.
//     * @param useDefault true if any existing property value should be
//     *        copied to the variable; false if the variable should not
//     *        be modified; defaults to true.
//     */
//    void
//    Tie (const std::string &name, bool *pointer, bool useDefault = true);


//    /**
//     * Tie a property to an external int variable.
//     *
//     * The property's value will automatically mirror the variable's
//     * value, and vice-versa, until the property is untied.
//     *
//     * @param name The property name to tie (full path).
//     * @param pointer A pointer to the variable.
//     * @param useDefault true if any existing property value should be
//     *        copied to the variable; false if the variable should not
//     *        be modified; defaults to true.
//     */
//    void
//    Tie (const std::string &name, int *pointer, bool useDefault = true);


//    /**
//     * Tie a property to an external long variable.
//     *
//     * The property's value will automatically mirror the variable's
//     * value, and vice-versa, until the property is untied.
//     *
//     * @param name The property name to tie (full path).
//     * @param pointer A pointer to the variable.
//     * @param useDefault true if any existing property value should be
//     *        copied to the variable; false if the variable should not
//     *        be modified; defaults to true.
//     */
//    void
//    Tie (const std::string &name, long *pointer, bool useDefault = true);


//    /**
//     * Tie a property to an external float variable.
//     *
//     * The property's value will automatically mirror the variable's
//     * value, and vice-versa, until the property is untied.
//     *
//     * @param name The property name to tie (full path).
//     * @param pointer A pointer to the variable.
//     * @param useDefault true if any existing property value should be
//     *        copied to the variable; false if the variable should not
//     *        be modified; defaults to true.
//     */
//    void
//    Tie (const std::string &name, float *pointer, bool useDefault = true);

//    /**
//     * Tie a property to an external double variable.
//     *
//     * The property's value will automatically mirror the variable's
//     * value, and vice-versa, until the property is untied.
//     *
//     * @param name The property name to tie (full path).
//     * @param pointer A pointer to the variable.
//     * @param useDefault true if any existing property value should be
//     *        copied to the variable; false if the variable should not
//     *        be modified; defaults to true.
//     */
//    void
//    Tie (const std::string &name, double *pointer, bool useDefault = true);

////============================================================================
////
////  All of the following functions *must* be inlined, otherwise linker
////  errors will result
////
////============================================================================

//    /* template <class V> void
//    Tie (const std::string &name, V (*getter)(), void (*setter)(V) = 0,
//           bool useDefault = true);

//    template <class V> void
//    Tie (const std::string &name, int index, V (*getter)(int),
//           void (*setter)(int, V) = 0, bool useDefault = true);

//    template <class T, class V> void
//    Tie (const std::string &name, T * obj, V (T::*getter)() const,
//           void (T::*setter)(V) = 0, bool useDefault = true);

//    template <class T, class V> void
//    Tie (const std::string &name, T * obj, int index,
//           V (T::*getter)(int) const, void (T::*setter)(int, V) = 0,
//           bool useDefault = true); */

//     /**
//     * Tie a property to a pair of simple functions.
//     *
//     * Every time the property value is queried, the getter (if any) will
//     * be invoked; every time the property value is modified, the setter
//     * (if any) will be invoked.  The getter can be 0 to make the property
//     * unreadable, and the setter can be 0 to make the property
//     * unmodifiable.
//     *
//     * @param name The property name to tie (full path).
//     * @param getter The getter function, or 0 if the value is unreadable.
//     * @param setter The setter function, or 0 if the value is unmodifiable.
//     * @param useDefault true if the setter should be invoked with any existing
//     *        property value should be; false if the old value should be
//     *        discarded; defaults to true.
//     */

//    template <class V> inline void
//    Tie (const std::string &name, V (*getter)(), void (*setter)(V) = 0, bool useDefault = true)
//    {
//      SGPropertyNode* property = root->getNode(name.c_str(), true);
//      if (!property) {
//        std::cerr << "Could not get or create property " << name << std::endl;
//        return;
//      }

//      if (!property->tie(SGRawValueFunctions<V>(getter, setter), useDefault))
//        std::cerr << "Failed to tie property " << name << " to functions" << std::endl;
//      else {
//        if (setter == 0) property->setAttribute(SGPropertyNode::WRITE, false);
//        if (getter == 0) property->setAttribute(SGPropertyNode::READ, false);
//        tied_properties.push_back(property);
//        if (FGJSBBase::debug_lvl & 0x20) std::cout << name << std::endl;
//      }
//    }


//    /**
//     * Tie a property to a pair of indexed functions.
//     *
//     * Every time the property value is queried, the getter (if any) will
//     * be invoked with the index provided; every time the property value
//     * is modified, the setter (if any) will be invoked with the index
//     * provided.  The getter can be 0 to make the property unreadable, and
//     * the setter can be 0 to make the property unmodifiable.
//     *
//     * @param name The property name to tie (full path).
//     * @param index The integer argument to pass to the getter and
//     *        setter functions.
//     * @param getter The getter function, or 0 if the value is unreadable.
//     * @param setter The setter function, or 0 if the value is unmodifiable.
//     * @param useDefault true if the setter should be invoked with any existing
//     *        property value should there be one; false if the old value should be
//     *        discarded; defaults to true.
//     */
//    template <class V> inline void Tie (const std::string &name, int index, V (*getter)(int),
//                                void (*setter)(int, V) = 0, bool useDefault = true)
//    {
//      SGPropertyNode* property = root->getNode(name.c_str(), true);
//      if (!property) {
//        std::cerr << "Could not get or create property " << name << std::endl;
//        return;
//      }

//      if (!property->tie(SGRawValueFunctionsIndexed<V>(index, getter, setter), useDefault))
//        std::cerr << "Failed to tie property " << name << " to indexed functions" << std::endl;
//      else {
//        if (setter == 0) property->setAttribute(SGPropertyNode::WRITE, false);
//        if (getter == 0) property->setAttribute(SGPropertyNode::READ, false);
//        tied_properties.push_back(property);
//        if (FGJSBBase::debug_lvl & 0x20) std::cout << name << std::endl;
//      }
//    }


//    /**
//     * Tie a property to a pair of object methods.
//     *
//     * Every time the property value is queried, the getter (if any) will
//     * be invoked; every time the property value is modified, the setter
//     * (if any) will be invoked.  The getter can be 0 to make the property
//     * unreadable, and the setter can be 0 to make the property
//     * unmodifiable.
//     *
//     * @param name The property name to tie (full path).
//     * @param obj The object whose methods should be invoked.
//     * @param getter The object's getter method, or 0 if the value is
//     *        unreadable.
//     * @param setter The object's setter method, or 0 if the value is
//     *        unmodifiable.
//     * @param useDefault true if the setter should be invoked with any existing
//     *        property value should there be one; false if the old value should be
//     *        discarded; defaults to true.
//     */
//    template <class T, class V> inline void
//    Tie (const std::string &name, T * obj, V (T::*getter)() const,
//           void (T::*setter)(V) = 0, bool useDefault = true)
//    {
//      SGPropertyNode* property = root->getNode(name.c_str(), true);
//      if (!property) {
//        std::cerr << "Could not get or create property " << name << std::endl;
//        return;
//      }

//      if (!property->tie(SGRawValueMethods<T,V>(*obj, getter, setter), useDefault))
//        std::cerr << "Failed to tie property " << name << " to object methods" << std::endl;
//      else {
//        if (setter == 0) property->setAttribute(SGPropertyNode::WRITE, false);
//        if (getter == 0) property->setAttribute(SGPropertyNode::READ, false);
//        tied_properties.push_back(property);
//        if (FGJSBBase::debug_lvl & 0x20) std::cout << name << std::endl;
//      }
//    }

//    /**
//     * Tie a property to a pair of indexed object methods.
//     *
//     * Every time the property value is queried, the getter (if any) will
//     * be invoked with the index provided; every time the property value
//     * is modified, the setter (if any) will be invoked with the index
//     * provided.  The getter can be 0 to make the property unreadable, and
//     * the setter can be 0 to make the property unmodifiable.
//     *
//     * @param name The property name to tie (full path).
//     * @param obj The object whose methods should be invoked.
//     * @param index The integer argument to pass to the getter and
//     *        setter methods.
//     * @param getter The getter method, or 0 if the value is unreadable.
//     * @param setter The setter method, or 0 if the value is unmodifiable.
//     * @param useDefault true if the setter should be invoked with any existing
//     *        property value should be; false if the old value should be
//     *        discarded; defaults to true.
//     */
//    template <class T, class V> inline void
//    Tie (const std::string &name, T * obj, int index, V (T::*getter)(int) const,
//                         void (T::*setter)(int, V) = 0, bool useDefault = true)
//    {
//      SGPropertyNode* property = root->getNode(name.c_str(), true);
//      if (!property) {
//        std::cerr << "Could not get or create property " << name << std::endl;
//        return;
//      }

//      if (!property->tie(SGRawValueMethodsIndexed<T,V>(*obj, index, getter, setter), useDefault))
//        std::cerr << "Failed to tie property " << name << " to indexed object methods" << std::endl;
//      else {
//        if (setter == 0) property->setAttribute(SGPropertyNode::WRITE, false);
//        if (getter == 0) property->setAttribute(SGPropertyNode::READ, false);
//        tied_properties.push_back(property);
//        if (FGJSBBase::debug_lvl & 0x20) std::cout << name << std::endl;
//      }
//   }

//  private:
//    std::vector<SGPropertyNode_ptr> tied_properties;
//    FGPropertyNode_ptr root;
//};
//}
//#endif // FGPROPERTYMANAGER_H

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

// Header:       FGPropertyManager.cpp
// Author:       Tony Peden
//               Based on work originally by David Megginson
// Date:         2/2002

// ------------- Copyright (C) 2002 -------------

// This program is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free Software
// Foundation; either version 2 of the License, or (at your option) any later
// version.

// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public License for more
// details.

// You should have received a copy of the GNU Lesser General Public License along with
// this program; if not, write to the Free Software Foundation, Inc., 59 Temple
// Place - Suite 330, Boston, MA  02111-1307, USA.

// Further information about the GNU Lesser General Public License can also be found on
// the world wide web at http://www.gnu.org.

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//INCLUDES
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//#include "FGPropertyManager.h"

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//DEFINITIONS
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/


///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//FORWARD DECLARATIONS
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*/

//using namespace std;

///*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//COMMENTS, REFERENCES, and NOTES [use "class documentation" below for API docs]
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//*/

//namespace JSBSim {

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Unbind(void)
//{
//    vector<SGPropertyNode_ptr>::iterator it;

//    for (it = tied_properties.begin();it < tied_properties.end();it++)
//        (*it)->untie();

//    tied_properties.clear();
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyManager::mkPropertyName(string name, bool lowercase) {

//  /* do this two pass to avoid problems with characters getting skipped
//     because the index changed */
//  unsigned i;
//  for(i=0;i<name.length();i++) {
//    if( lowercase && isupper(name[i]) )
//      name[i]=tolower(name[i]);
//    else if( isspace(name[i]) )
//      name[i]='-';
//  }
  
//  return name;
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//FGPropertyNode*
//FGPropertyNode::GetNode (const string &path, bool create)
//{
//  SGPropertyNode* node = getNode(path.c_str(), create);
//  if (node == 0) {
//    cerr << "FGPropertyManager::GetNode() No node found for " << path << endl;
//  }
//  return (FGPropertyNode*)node;
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//FGPropertyNode*
//FGPropertyNode::GetNode (const string &relpath, int index, bool create)
//{
//  SGPropertyNode* node = getNode(relpath.c_str(), index, create);
//  if (node == 0) {
//    cerr << "FGPropertyManager::GetNode() No node found for " << relpath
//         << "[" << index << "]" << endl;
//  }
//  return (FGPropertyNode*)node;
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::HasNode (const string &path)
//{
//  const SGPropertyNode* node = getNode(path.c_str(), false);
//  return (node != 0);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyNode::GetName( void ) const
//{
//  return string( getName() );
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyNode::GetPrintableName( void ) const
//{
//  string temp_string(getName());
//  size_t initial_location=0;
//  size_t found_location;

//  found_location = temp_string.rfind("/");
//  if (found_location != string::npos)
//  temp_string = temp_string.substr(found_location);

//  found_location = temp_string.find('_',initial_location);
//  while (found_location != string::npos) {
//    temp_string.replace(found_location,1," ");
//    initial_location = found_location+1;
//    found_location = temp_string.find('_',initial_location);
//  }
//  return temp_string;
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyNode::GetFullyQualifiedName(void) const
//{
//    vector<string> stack;
//    stack.push_back( getDisplayName(true) );
//    const SGPropertyNode* tmpn=getParent();
//    bool atroot=false;
//    while( !atroot ) {
//     stack.push_back( tmpn->getDisplayName(true) );
//     if( !tmpn->getParent() )
//      atroot=true;
//     else
//      tmpn=tmpn->getParent();
//    }

//    string fqname="";
//    for(unsigned i=stack.size()-1;i>0;i--) {
//      fqname+= stack[i];
//      fqname+= "/";
//    }
//    fqname+= stack[0];
//    return fqname;

//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyNode::GetRelativeName( const string &path ) const
//{
//  string temp_string = GetFullyQualifiedName();
//  size_t len = path.length();
//  if ( (len > 0) && (temp_string.substr(0,len) == path) ) {
//    temp_string = temp_string.erase(0,len);
//  }
//  return temp_string;
//}



////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::GetBool (const string &name, bool defaultValue) const
//{
//  return getBoolValue(name.c_str(), defaultValue);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//int FGPropertyNode::GetInt (const string &name, int defaultValue ) const
//{
//  return getIntValue(name.c_str(), defaultValue);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//int FGPropertyNode::GetLong (const string &name, long defaultValue ) const
//{
//  return getLongValue(name.c_str(), defaultValue);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//float FGPropertyNode::GetFloat (const string &name, float defaultValue ) const
//{
//  return getFloatValue(name.c_str(), defaultValue);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//double FGPropertyNode::GetDouble (const string &name, double defaultValue ) const
//{
//  return getDoubleValue(name.c_str(), defaultValue);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//string FGPropertyNode::GetString (const string &name, string defaultValue ) const
//{
//  return string(getStringValue(name.c_str(), defaultValue.c_str()));
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetBool (const string &name, bool val)
//{
//  return setBoolValue(name.c_str(), val);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetInt (const string &name, int val)
//{
//  return setIntValue(name.c_str(), val);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetLong (const string &name, long val)
//{
//  return setLongValue(name.c_str(), val);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetFloat (const string &name, float val)
//{
//  return setFloatValue(name.c_str(), val);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetDouble (const string &name, double val)
//{
//  return setDoubleValue(name.c_str(), val);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//bool FGPropertyNode::SetString (const string &name, const string &val)
//{
//  return setStringValue(name.c_str(), val.c_str());
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyNode::SetArchivable (const string &name, bool state )
//{
//  SGPropertyNode * node = getNode(name.c_str());
//  if (node == 0)
//    cerr <<
//           "Attempt to set archive flag for non-existent property "
//           << name << endl;
//  else
//    node->setAttribute(SGPropertyNode::ARCHIVE, state);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyNode::SetReadable (const string &name, bool state )
//{
//  SGPropertyNode * node = getNode(name.c_str());
//  if (node == 0)
//    cerr <<
//           "Attempt to set read flag for non-existant property "
//           << name << endl;
//  else
//    node->setAttribute(SGPropertyNode::READ, state);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyNode::SetWritable (const string &name, bool state )
//{
//  SGPropertyNode * node = getNode(name.c_str());
//  if (node == 0)
//    cerr <<
//           "Attempt to set write flag for non-existant property "
//           << name << endl;
//  else
//    node->setAttribute(SGPropertyNode::WRITE, state);
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Untie (const string &name)
//{
//  SGPropertyNode* property = root->getNode(name.c_str());
//  if (!property) {
//    cerr << "Attempt to untie a non-existant property." << name << endl;
//    return;
//  }

//  vector <SGPropertyNode_ptr>::iterator it;
//  for (it = tied_properties.begin(); it != tied_properties.end(); ++it) {
//    if (*it == property) {
//      property->untie();
//      tied_properties.erase(it);
//      if (FGJSBBase::debug_lvl & 0x20) cout << "Untied " << name << endl;
//      return;
//    }
//  }

//  cerr << "Failed to untie property " << name << endl
//       << "JSBSim is not the owner of this property." << endl;
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Tie (const string &name, bool *pointer, bool useDefault)
//{
//  SGPropertyNode* property = root->getNode(name.c_str(), true);
//  if (!property) {
//    cerr << "Could not get or create property " << name << endl;
//    return;
//  }

//  if (!property->tie(SGRawValuePointer<bool>(pointer), useDefault))
//    cerr << "Failed to tie property " << name << " to a pointer" << endl;
//  else {
//    tied_properties.push_back(property);
//    if (FGJSBBase::debug_lvl & 0x20) cout << name << endl;
//  }
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Tie (const string &name, int *pointer,
//                                          bool useDefault )
//{
//  SGPropertyNode* property = root->getNode(name.c_str(), true);
//  if (!property) {
//    cerr << "Could not get or create property " << name << endl;
//    return;
//  }

//  if (!property->tie(SGRawValuePointer<int>(pointer), useDefault))
//    cerr << "Failed to tie property " << name << " to a pointer" << endl;
//  else {
//    tied_properties.push_back(property);
//    if (FGJSBBase::debug_lvl & 0x20) cout << name << endl;
//  }
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Tie (const string &name, long *pointer,
//                                          bool useDefault )
//{
//  SGPropertyNode* property = root->getNode(name.c_str(), true);
//  if (!property) {
//    cerr << "Could not get or create property " << name << endl;
//    return;
//  }

//  if (!property->tie(SGRawValuePointer<long>(pointer), useDefault))
//    cerr << "Failed to tie property " << name << " to a pointer" << endl;
//  else {
//    tied_properties.push_back(property);
//    if (FGJSBBase::debug_lvl & 0x20) cout << name << endl;
//  }
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Tie (const string &name, float *pointer,
//                                          bool useDefault )
//{
//  SGPropertyNode* property = root->getNode(name.c_str(), true);
//  if (!property) {
//    cerr << "Could not get or create property " << name << endl;
//    return;
//  }

//  if (!property->tie(SGRawValuePointer<float>(pointer), useDefault))
//    cerr << "Failed to tie property " << name << " to a pointer" << endl;
//  else {
//    tied_properties.push_back(property);
//    if (FGJSBBase::debug_lvl & 0x20) cout << name << endl;
//  }
//}

////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

//void FGPropertyManager::Tie (const string &name, double *pointer, bool useDefault)
//{
//  SGPropertyNode* property = root->getNode(name.c_str(), true);
//  if (!property) {
//    cerr << "Could not get or create property " << name << endl;
//    return;
//  }

//  if (!property->tie(SGRawValuePointer<double>(pointer), useDefault))
//    cerr << "Failed to tie property " << name << " to a pointer" << endl;
//  else {
//    tied_properties.push_back(property);
//    if (FGJSBBase::debug_lvl & 0x20) cout << name << endl;
//  }
//}

//} // namespace JSBSim
