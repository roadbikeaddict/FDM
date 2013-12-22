//namespace FDM.InputOutput
//{
//    public class PropertyNode
//    {
//        class FGPropertyNode : public SGPropertyNode
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

 
//    }
//}