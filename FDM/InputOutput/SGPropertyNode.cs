//namespace FDM.InputOutput
//{
//    public class SGPropertyNode
//    {
//        private int MAX_STRING_LEN = 1024;
  
//        // Property value types.
   
//        enum PropertyValeType 
//        {
//            NONE = 0,
//            ALIAS,
//            BOOL,
//            INT,
//            LONG,
//            FLOAT,
//            DOUBLE,
//            STRING,
//            UNSPECIFIED
//        };


//        /**
//           * Access mode attributes.
//           *
//           * <p>The ARCHIVE attribute is strictly advisory, and controls
//           * whether the property should normally be saved and restored.</p>
//           */
//        enum AccessModeAttribute {
//            READ = 1,
//            WRITE = 2,
//            ARCHIVE = 4,
//            REMOVED = 8,
//            TRACE_READ = 16,
//            TRACE_WRITE = 32,
//            USERARCHIVE = 64
//        };


//        /**
//         * Last used attribute
//        * Update as needed when enum Attribute is changed
//        */
//        static const int LAST_USED_ATTRIBUTE;


//        /**
//        * Default constructor.
//        */
//        public SGPropertyNode()
//        {
            
//        }

//        /**
//        * Copy constructor.
//        */
//        public SGPropertyNode(SGPropertyNode node)
//        {
            
//        }

//        /**
//        * Test whether this node contains a primitive leaf value.
//        */
//        public bool HasValue()
//        {
//            return (_type != NONE);
//        }


//        /**
//        * Get the node's simple (XML) name.
//        */
//        public string GetName()
//        {
//            return _name.c_str();
//        }


//  /**
//   * Get the node's pretty display name, with subscript when needed.
//   */
//  const char * getDisplayName (bool simplify = false) const;


//  /**
//   * Get the node's integer index.
//   */
//  int getIndex () const { return _index; }


//  /**
//   * Get a non-const pointer to the node's parent.
//   */
//  SGPropertyNode * getParent () { return _parent; }


//  /**
//   * Get a const pointer to the node's parent.
//   */
//  const SGPropertyNode * getParent () const { return _parent; }


//  //
//  // Children.
//  //


//  /**
//   * Get the number of child nodes.
//   */
//  int nChildren () const { return (int)_children.size(); }


//  /**
//   * Get a child node by position (*NOT* index).
//   */
//  SGPropertyNode * getChild (int position);


//  /**
//   * Get a const child node by position (*NOT* index).
//   */
//  const SGPropertyNode * getChild (int position) const;


//  /**
//   * Test whether a named child exists.
//   */
//  bool hasChild (const char * name, int index = 0) const
//  {
//    return (getChild(name, index) != 0);
//  }


//  /**
//   * Get a child node by name and index.
//   */
//  SGPropertyNode * getChild (const char * name, int index = 0,
//                 bool create = false);


//  /**
//   * Get a const child node by name and index.
//   */
//  const SGPropertyNode * getChild (const char * name, int index = 0) const;


//  /**
//   * Get a vector of all children with the specified name.
//   */
//  vector<SGPropertyNode_ptr> getChildren (const char * name) const;


//  /**
//   * Remove child by position.
//   */
//  SGPropertyNode_ptr removeChild (int pos, bool keep = true);


//  /**
//   * Remove a child node
//   */
//  SGPropertyNode_ptr removeChild (const char * name, int index = 0,
//                                  bool keep = true);

//  /**
//   * Remove all children with the specified name.
//   */
//  vector<SGPropertyNode_ptr> removeChildren (const char * name,
//                                             bool keep = true);


//  //
//  // Alias support.
//  //


//  /**
//   * Alias this node's leaf value to another's.
//   */
//  bool alias (SGPropertyNode * target);


//  /**
//   * Alias this node's leaf value to another's by relative path.
//   */
//  bool alias (const char * path);


//  /**
//   * Remove any alias for this node.
//   */
//  bool unalias ();


//  /**
//   * Test whether the node's leaf value is aliased to another's.
//   */
//  bool isAlias () const { return (_type == ALIAS); }


//  /**
//   * Get a non-const pointer to the current alias target, if any.
//   */
//  SGPropertyNode * getAliasTarget ();


//  /**
//   * Get a const pointer to the current alias target, if any.
//   */
//  const SGPropertyNode * getAliasTarget () const;


//  //
//  // Path information.
//  //


//  /**
//   * Get the path to this node from the root.
//   */
//  const char * getPath (bool simplify = false) const;


//  /**
//   * Get a pointer to the root node.
//   */
//  SGPropertyNode * getRootNode ();


//  /**
//   * Get a const pointer to the root node.
//   */
//  const SGPropertyNode * getRootNode () const;


//  /**
//   * Get a pointer to another node by relative path.
//   */
//  SGPropertyNode * getNode (const char * relative_path, bool create = false);


//  /**
//   * Get a pointer to another node by relative path.
//   *
//   * This method leaves the index off the last member of the path,
//   * so that the user can specify it separately (and save some
//   * string building).  For example, getNode("/bar[1]/foo", 3) is
//   * exactly equivalent to getNode("bar[1]/foo[3]").  The index
//   * provided overrides any given in the path itself for the last
//   * component.
//   */
//  SGPropertyNode * getNode (const char * relative_path, int index,
//                bool create = false);


//  /**
//   * Get a const pointer to another node by relative path.
//   */
//  const SGPropertyNode * getNode (const char * relative_path) const;


//  /**
//   * Get a const pointer to another node by relative path.
//   *
//   * This method leaves the index off the last member of the path,
//   * so that the user can specify it separate.
//   */
//  const SGPropertyNode * getNode (const char * relative_path,
//                  int index) const;


//  //
//  // Access Mode.
//  //

//  /**
//   * Check a single mode attribute for the property node.
//   */
//  bool getAttribute (Attribute attr) const { return ((_attr & attr) != 0); }


//  /**
//   * Set a single mode attribute for the property node.
//   */
//  void setAttribute (Attribute attr, bool state) {
//    (state ? _attr |= attr : _attr &= ~attr);
//  }


//  /**
//   * Get all of the mode attributes for the property node.
//   */
//  int getAttributes () const { return _attr; }


//  /**
//   * Set all of the mode attributes for the property node.
//   */
//  void setAttributes (int attr) { _attr = attr; }


//  //
//  // Leaf Value (primitive).
//  //


//  /**
//   * Get the type of leaf value, if any, for this node.
//   */
//  Type getType () const;


//  /**
//   * Get a bool value for this node.
//   */
//  bool getBoolValue () const;


//  /**
//   * Get an int value for this node.
//   */
//  int getIntValue () const;


//  /**
//   * Get a long int value for this node.
//   */
//  long getLongValue () const;


//  /**
//   * Get a float value for this node.
//   */
//  float getFloatValue () const;


//  /**
//   * Get a double value for this node.
//   */
//  double getDoubleValue () const;


//  /**
//   * Get a string value for this node.
//   */
//  const char * getStringValue () const;



//  /**
//   * Set a bool value for this node.
//   */
//  bool setBoolValue (bool value);


//  /**
//   * Set an int value for this node.
//   */
//  bool setIntValue (int value);


//  /**
//   * Set a long int value for this node.
//   */
//  bool setLongValue (long value);


//  /**
//   * Set a float value for this node.
//   */
//  bool setFloatValue (float value);


//  /**
//   * Set a double value for this node.
//   */
//  bool setDoubleValue (double value);


//  /**
//   * Set a string value for this node.
//   */
//  bool setStringValue (const char * value);


//  /**
//   * Set a value of unspecified type for this node.
//   */
//  bool setUnspecifiedValue (const char * value);


//  //
//  // Data binding.
//  //


//  /**
//   * Test whether this node is bound to an external data source.
//   */
//  bool isTied () const { return _tied; }


//  /**
//   * Bind this node to an external bool source.
//   */
//  bool tie (const SGRawValue<bool> &rawValue, bool useDefault = true);


//  /**
//   * Bind this node to an external int source.
//   */
//  bool tie (const SGRawValue<int> &rawValue, bool useDefault = true);


//  /**
//   * Bind this node to an external long int source.
//   */
//  bool tie (const SGRawValue<long> &rawValue, bool useDefault = true);


//  /**
//   * Bind this node to an external float source.
//   */
//  bool tie (const SGRawValue<float> &rawValue, bool useDefault = true);


//  /**
//   * Bind this node to an external double source.
//   */
//  bool tie (const SGRawValue<double> &rawValue, bool useDefault = true);


//  /**
//   * Bind this node to an external string source.
//   */
//  bool tie (const SGRawValue<const char *> &rawValue, bool useDefault = true);


//  /**
//   * Unbind this node from any external data source.
//   */
//  bool untie ();


//  //
//  // Convenience methods using paths.
//  // TODO: add attribute methods
//  //


//  /**
//   * Get another node's type.
//   */
//  Type getType (const char * relative_path) const;


//  /**
//   * Test whether another node has a leaf value.
//   */
//  bool hasValue (const char * relative_path) const;


//  /**
//   * Get another node's value as a bool.
//   */
//  bool getBoolValue (const char * relative_path,
//             bool defaultValue = false) const;


//  /**
//   * Get another node's value as an int.
//   */
//  int getIntValue (const char * relative_path,
//           int defaultValue = 0) const;


//  /**
//   * Get another node's value as a long int.
//   */
//  long getLongValue (const char * relative_path,
//             long defaultValue = 0L) const;


//  /**
//   * Get another node's value as a float.
//   */
//  float getFloatValue (const char * relative_path,
//               float defaultValue = 0.0) const;


//  /**
//   * Get another node's value as a double.
//   */
//  double getDoubleValue (const char * relative_path,
//             double defaultValue = 0.0L) const;


//  /**
//   * Get another node's value as a string.
//   */
//  const char * getStringValue (const char * relative_path,
//                   const char * defaultValue = "") const;


//  /**
//   * Set another node's value as a bool.
//   */
//  bool setBoolValue (const char * relative_path, bool value);


//  /**
//   * Set another node's value as an int.
//   */
//  bool setIntValue (const char * relative_path, int value);


//  /**
//   * Set another node's value as a long int.
//   */
//  bool setLongValue (const char * relative_path, long value);


//  /**
//   * Set another node's value as a float.
//   */
//  bool setFloatValue (const char * relative_path, float value);


//  /**
//   * Set another node's value as a double.
//   */
//  bool setDoubleValue (const char * relative_path, double value);


//  /**
//   * Set another node's value as a string.
//   */
//  bool setStringValue (const char * relative_path, const char * value);


//  /**
//   * Set another node's value with no specified type.
//   */
//  bool setUnspecifiedValue (const char * relative_path, const char * value);


//  /**
//   * Test whether another node is bound to an external data source.
//   */
//  bool isTied (const char * relative_path) const;


//  /**
//   * Bind another node to an external bool source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<bool> &rawValue,
//        bool useDefault = true);


//  /**
//   * Bind another node to an external int source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<int> &rawValue,
//        bool useDefault = true);


//  /**
//   * Bind another node to an external long int source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<long> &rawValue,
//        bool useDefault = true);


//  /**
//   * Bind another node to an external float source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<float> &rawValue,
//        bool useDefault = true);


//  /**
//   * Bind another node to an external double source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<double> &rawValue,
//        bool useDefault = true);


//  /**
//   * Bind another node to an external string source.
//   */
//  bool tie (const char * relative_path, const SGRawValue<const char *> &rawValue,
//        bool useDefault = true);


//  /**
//   * Unbind another node from any external data source.
//   */
//  bool untie (const char * relative_path);


//  /**
//   * Add a change listener to the property. If "initial" is set call the
//   * listener initially.
//   */
//  void addChangeListener (SGPropertyChangeListener * listener,
//                          bool initial = false);


//  /**
//   * Remove a change listener from the property.
//   */
//  void removeChangeListener (SGPropertyChangeListener * listener);


//  /**
//   * Fire a value change event to all listeners.
//   */
//  void fireValueChanged ();


//  /**
//   * Fire a child-added event to all listeners.
//   */
//  void fireChildAdded (SGPropertyNode * child);


//  /**
//   * Fire a child-removed event to all listeners.
//   */
//  void fireChildRemoved (SGPropertyNode * child);


//  /**
//   * Clear any existing value and set the type to NONE.
//   */
//  void clearValue ();


//protected:

//  void fireValueChanged (SGPropertyNode * node);
//  void fireChildAdded (SGPropertyNode * parent, SGPropertyNode * child);
//  void fireChildRemoved (SGPropertyNode * parent, SGPropertyNode * child);

//  /**
//   * Protected constructor for making new nodes on demand.
//   */
//  SGPropertyNode (const char * name, int index, SGPropertyNode * parent);


//private:

//                // Get the raw value
//  bool get_bool () const;
//  int get_int () const;
//  long get_long () const;
//  float get_float () const;
//  double get_double () const;
//  const char * get_string () const;

//                // Set the raw value
//  bool set_bool (bool value);
//  bool set_int (int value);
//  bool set_long (long value);
//  bool set_float (float value);
//  bool set_double (double value);
//  bool set_string (const char * value);


//  /**
//   * Get the value as a string.
//   */
//  const char * make_string () const;


//  /**
//   * Trace a read access.
//   */
//  void trace_read () const;


//  /**
//   * Trace a write access.
//   */
//  void trace_write () const;


//  class hash_table;

//  int _index;
//  string _name;
//  mutable string _display_name;
//  /// To avoid cyclic reference counting loops this shall not be a reference
//  /// counted pointer
//  SGPropertyNode * _parent;
//  vector<SGPropertyNode_ptr> _children;
//  vector<SGPropertyNode_ptr> _removedChildren;
//  mutable string _path;
//  mutable string _buffer;
//  hash_table * _path_cache;
//  Type _type;
//  bool _tied;
//  int _attr;

//                // The right kind of pointer...
//  union {
//    SGPropertyNode * alias;
//    SGRawValue<bool> * bool_val;
//    SGRawValue<int> * int_val;
//    SGRawValue<long> * long_val;
//    SGRawValue<float> * float_val;
//    SGRawValue<double> * double_val;
//    SGRawValue<const char *> * string_val;
//  } _value;

//  union {
//    bool bool_val;
//    int int_val;
//    long long_val;
//    float float_val;
//    double double_val;
//    char * string_val;
//  } _local_val;

//  vector <SGPropertyChangeListener *> * _listeners;



//  /**
//   * A very simple hash table with no remove functionality.
//   */
//  class hash_table {
//  public:

//    /**
//     * An entry in a bucket in a hash table.
//     */
//    class entry {
//    public:
//      entry ();
//      ~entry ();
//      const char * get_key () { return _key.c_str(); }
//      void set_key (const char * key);
//      SGPropertyNode * get_value () { return _value; }
//      void set_value (SGPropertyNode * value);
//    private:
//      string _key;
//      SGSharedPtr<SGPropertyNode>  _value;
//    };


//    /**
//     * A bucket in a hash table.
//     */
//    class bucket {
//    public:
//      bucket ();
//      ~bucket ();
//      entry * get_entry (const char * key, bool create = false);
//      void erase(const char * key);
//    private:
//      int _length;
//      entry ** _entries;
//    };

//    friend class bucket;

//    hash_table ();
//    ~hash_table ();
//    SGPropertyNode * get (const char * key);
//    void put (const char * key, SGPropertyNode * value);
//    void erase(const char * key);

//  private:
//    unsigned int hashcode (const char * key);
//    unsigned int _data_length;
//    bucket ** _data;
//  };

//};

 
//////////////////////////////////////////////////////////////////////////
//// Private methods from SGPropertyNode (may be inlined for speed).
//////////////////////////////////////////////////////////////////////////

//inline bool
//SGPropertyNode::get_bool () const
//{
//  if (_tied)
//    return _value.bool_val->getValue();
//  else
//    return _local_val.bool_val;
//}

//inline int
//SGPropertyNode::get_int () const
//{
//  if (_tied)
//    return _value.int_val->getValue();
//  else
//    return _local_val.int_val;
//}

//inline long
//SGPropertyNode::get_long () const
//{
//  if (_tied)
//    return _value.long_val->getValue();
//  else
//    return _local_val.long_val;
//}

//inline float
//SGPropertyNode::get_float () const
//{
//  if (_tied)
//    return _value.float_val->getValue();
//  else
//    return _local_val.float_val;
//}

//inline double
//SGPropertyNode::get_double () const
//{
//  if (_tied)
//    return _value.double_val->getValue();
//  else
//    return _local_val.double_val;
//}

//inline const char *
//SGPropertyNode::get_string () const
//{
//  if (_tied)
//    return _value.string_val->getValue();
//  else
//    return _local_val.string_val;
//}

//inline bool
//SGPropertyNode::set_bool (bool val)
//{
//  if (_tied) {
//    if (_value.bool_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    _local_val.bool_val = val;
//    fireValueChanged();
//    return true;
//  }
//}

//inline bool
//SGPropertyNode::set_int (int val)
//{
//  if (_tied) {
//    if (_value.int_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    _local_val.int_val = val;
//    fireValueChanged();
//    return true;
//  }
//}

//inline bool
//SGPropertyNode::set_long (long val)
//{
//  if (_tied) {
//    if (_value.long_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    _local_val.long_val = val;
//    fireValueChanged();
//    return true;
//  }
//}

//inline bool
//SGPropertyNode::set_float (float val)
//{
//  if (_tied) {
//    if (_value.float_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    _local_val.float_val = val;
//    fireValueChanged();
//    return true;
//  }
//}

//inline bool
//SGPropertyNode::set_double (double val)
//{
//  if (_tied) {
//    if (_value.double_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    _local_val.double_val = val;
//    fireValueChanged();
//    return true;
//  }
//}

//inline bool
//SGPropertyNode::set_string (const char * val)
//{
//  if (_tied) {
//    if (_value.string_val->setValue(val)) {
//      fireValueChanged();
//      return true;
//    } else {
//      return false;
//    }
//  } else {
//    delete [] _local_val.string_val;
//    _local_val.string_val = copy_string(val);
//    fireValueChanged();
//    return true;
//  }
//}

//void
//SGPropertyNode::clearValue ()
//{
//  switch (_type) {
//  case NONE:
//    break;
//  case ALIAS:
//    _value.alias = 0;
//    break;
//  case BOOL:
//    if (_tied) {
//      delete _value.bool_val;
//      _value.bool_val = 0;
//    }
//    _local_val.bool_val = SGRawValue<bool>::DefaultValue;
//    break;
//  case INT:
//    if (_tied) {
//      delete _value.int_val;
//      _value.int_val = 0;
//    }
//    _local_val.int_val = SGRawValue<int>::DefaultValue;
//    break;
//  case LONG:
//    if (_tied) {
//      delete _value.long_val;
//      _value.long_val = 0L;
//    }
//    _local_val.long_val = SGRawValue<long>::DefaultValue;
//    break;
//  case FLOAT:
//    if (_tied) {
//      delete _value.float_val;
//      _value.float_val = 0;
//    }
//    _local_val.float_val = SGRawValue<float>::DefaultValue;
//    break;
//  case DOUBLE:
//    if (_tied) {
//      delete _value.double_val;
//      _value.double_val = 0;
//    }
//    _local_val.double_val = SGRawValue<double>::DefaultValue;
//    break;
//  case STRING:
//  case UNSPECIFIED:
//    if (_tied) {
//      delete _value.string_val;
//      _value.string_val = 0;
//    } else {
//      delete [] _local_val.string_val;
//    }
//    _local_val.string_val = 0;
//    break;
//  }
//  _tied = false;
//  _type = NONE;
//}


///**
// * Get the value as a string.
// */
//const char *
//SGPropertyNode::make_string () const
//{
//  if (!getAttribute(READ))
//    return "";

//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getStringValue();
//  case BOOL:
//    if (get_bool())
//      return "true";
//    else
//      return "false";
//  case INT:
//    {
//      stringstream sstr;
//      sstr << get_int();
//      _buffer = sstr.str();
//      return _buffer.c_str();
//    }
//  case LONG:
//    {
//      stringstream sstr;
//      sstr << get_long();
//      _buffer = sstr.str();
//      return _buffer.c_str();
//    }
//  case FLOAT:
//    {
//      stringstream sstr;
//      sstr << get_float();
//      _buffer = sstr.str();
//      return _buffer.c_str();
//    }
//  case DOUBLE:
//    {
//      stringstream sstr;
//      sstr.precision( 10 );
//      sstr << get_double();
//      _buffer = sstr.str();
//      return _buffer.c_str();
//    }
//  case STRING:
//  case UNSPECIFIED:
//    return get_string();
//  case NONE:
//  default:
//    return "";
//  }
//}

///**
// * Trace a write access for a property.
// */
//void
//SGPropertyNode::trace_write () const
//{
//#if PROPS_STANDALONE
//  cerr << "TRACE: Write node " << getPath () << ", value\""
//       << make_string() << '"' << endl;
//#else
//  SG_LOG(SG_GENERAL, SG_INFO, "TRACE: Write node " << getPath()
//  << ", value\"" << make_string() << '"');
//#endif
//}

///**
// * Trace a read access for a property.
// */
//void
//SGPropertyNode::trace_read () const
//{
//#if PROPS_STANDALONE
//  cerr << "TRACE: Write node " << getPath () << ", value \""
//       << make_string() << '"' << endl;
//#else
//  SG_LOG(SG_GENERAL, SG_INFO, "TRACE: Read node " << getPath()
//     << ", value \"" << make_string() << '"');
//#endif
//}


//////////////////////////////////////////////////////////////////////////
//// Public methods from SGPropertyNode.
//////////////////////////////////////////////////////////////////////////

///**
// * Last used attribute
// * Update as needed when enum Attribute is changed
// */
//const int SGPropertyNode::LAST_USED_ATTRIBUTE = TRACE_WRITE;

///**
// * Default constructor: always creates a root node.
// */
//SGPropertyNode::SGPropertyNode ()
//  : _index(0),
//    _parent(0),
//    _path_cache(0),
//    _type(NONE),
//    _tied(false),
//    _attr(READ|WRITE),
//    _listeners(0)
//{
//  _local_val.string_val = 0;
//}


///**
// * Copy constructor.
// */
//SGPropertyNode::SGPropertyNode (const SGPropertyNode &node)
//  : _index(node._index),
//    _name(node._name),
//    _parent(0),			// don't copy the parent
//    _path_cache(0),
//    _type(node._type),
//    _tied(node._tied),
//    _attr(node._attr),
//    _listeners(0)		// CHECK!!
//{
//  _local_val.string_val = 0;
//  switch (_type) {
//  case NONE:
//    break;
//  case ALIAS:
//    _value.alias = node._value.alias;
//    _tied = false;
//    break;
//  case BOOL:
//    if (_tied) {
//      _tied = true;
//      _value.bool_val = node._value.bool_val->clone();
//    } else {
//      _tied = false;
//      set_bool(node.get_bool());
//    }
//    break;
//  case INT:
//    if (_tied) {
//      _tied = true;
//      _value.int_val = node._value.int_val->clone();
//    } else {
//      _tied = false;
//      set_int(node.get_int());
//    }
//    break;
//  case LONG:
//    if (_tied) {
//      _tied = true;
//      _value.long_val = node._value.long_val->clone();
//    } else {
//      _tied = false;
//      set_long(node.get_long());
//    }
//    break;
//  case FLOAT:
//    if (_tied) {
//      _tied = true;
//      _value.float_val = node._value.float_val->clone();
//    } else {
//      _tied = false;
//      set_float(node.get_float());
//    }
//    break;
//  case DOUBLE:
//    if (_tied) {
//      _tied = true;
//      _value.double_val = node._value.double_val->clone();
//    } else {
//      _tied = false;
//      set_double(node.get_double());
//    }
//    break;
//  case STRING:
//  case UNSPECIFIED:
//    if (_tied) {
//      _tied = true;
//      _value.string_val = node._value.string_val->clone();
//    } else {
//      _tied = false;
//      set_string(node.get_string());
//    }
//    break;
//  }
//}


///**
// * Convenience constructor.
// */
//SGPropertyNode::SGPropertyNode (const char * name,
//                int index,
//                SGPropertyNode * parent)
//  : _index(index),
//    _parent(parent),
//    _path_cache(0),
//    _type(NONE),
//    _tied(false),
//    _attr(READ|WRITE),
//    _listeners(0)
//{
//  _name = name;
//  _local_val.string_val = 0;
//}


///**
// * Destructor.
// */
//SGPropertyNode::~SGPropertyNode ()
//{
//  delete _path_cache;
//  clearValue();
//  delete _listeners;
//}


///**
// * Alias to another node.
// */
//bool
//SGPropertyNode::alias (SGPropertyNode * target)
//{
//  if (target == 0 || _type == ALIAS || _tied)
//    return false;
//  clearValue();
//  _value.alias = target;
//  _type = ALIAS;
//  return true;
//}


///**
// * Alias to another node by path.
// */
//bool
//SGPropertyNode::alias (const char * path)
//{
//  return alias(getNode(path, true));
//}


///**
// * Remove an alias.
// */
//bool
//SGPropertyNode::unalias ()
//{
//  if (_type != ALIAS)
//    return false;
//  _type = NONE;
//  _value.alias = 0;
//  return true;
//}


///**
// * Get the target of an alias.
// */
//SGPropertyNode *
//SGPropertyNode::getAliasTarget ()
//{
//  return (_type == ALIAS ? _value.alias : 0);
//}


//const SGPropertyNode *
//SGPropertyNode::getAliasTarget () const
//{
//  return (_type == ALIAS ? _value.alias : 0);
//}


///**
// * Get a non-const child by index.
// */
//SGPropertyNode *
//SGPropertyNode::getChild (int position)
//{
//  if (position >= 0 && position < nChildren())
//    return _children[position];
//  else
//    return 0;
//}


///**
// * Get a const child by index.
// */
//const SGPropertyNode *
//SGPropertyNode::getChild (int position) const
//{
//  if (position >= 0 && position < nChildren())
//    return _children[position];
//  else
//    return 0;
//}


///**
// * Get a non-const child by name and index, creating if necessary.
// */
//SGPropertyNode *
//SGPropertyNode::getChild (const char * name, int index, bool create)
//{
//  int pos = find_child(name, index, _children);
//  if (pos >= 0) {
//    return _children[pos];
//  } else if (create) {
//    SGPropertyNode_ptr node;
//    pos = find_child(name, index, _removedChildren);
//    if (pos >= 0) {
//      vector<SGPropertyNode_ptr>::iterator it = _removedChildren.begin();
//      it += pos;
//      node = _removedChildren[pos];
//      _removedChildren.erase(it);
//      node->setAttribute(REMOVED, false);
//    } else {
//      node = new SGPropertyNode(name, index, this);
//    }
//    _children.push_back(node);
//    fireChildAdded(node);
//    return node;
//  } else {
//    return 0;
//  }
//}


///**
// * Get a const child by name and index.
// */
//const SGPropertyNode *
//SGPropertyNode::getChild (const char * name, int index) const
//{
//  int pos = find_child(name, index, _children);
//  if (pos >= 0)
//    return _children[pos];
//  else
//    return 0;
//}


///**
// * Get all children with the same name (but different indices).
// */
//vector<SGPropertyNode_ptr>
//SGPropertyNode::getChildren (const char * name) const
//{
//  vector<SGPropertyNode_ptr> children;
//  int max = _children.size();

//  for (int i = 0; i < max; i++)
//    if (compare_strings(_children[i]->getName(), name))
//      children.push_back(_children[i]);

//  sort(children.begin(), children.end(), CompareIndices());
//  return children;
//}


///**
// * Remove child by position.
// */
//SGPropertyNode_ptr
//SGPropertyNode::removeChild (int pos, bool keep)
//{
//  SGPropertyNode_ptr node;
//  if (pos < 0 || pos >= (int)_children.size())
//    return node;

//  vector<SGPropertyNode_ptr>::iterator it = _children.begin();
//  it += pos;
//  node = _children[pos];
//  _children.erase(it);
//  if (keep) {
//    _removedChildren.push_back(node);
//  }
//  if (_path_cache)
//     _path_cache->erase(node->getName()); // EMH - TODO: Take "index" into account!
//  node->setAttribute(REMOVED, true);
//  node->clearValue();
//  fireChildRemoved(node);
//  return node;
//}


///**
// * Remove a child node
// */
//SGPropertyNode_ptr
//SGPropertyNode::removeChild (const char * name, int index, bool keep)
//{
//  SGPropertyNode_ptr ret;
//  int pos = find_child(name, index, _children);
//  if (pos >= 0)
//    ret = removeChild(pos, keep);
//  return ret;
//}


///**
//  * Remove all children with the specified name.
//  */
//vector<SGPropertyNode_ptr>
//SGPropertyNode::removeChildren (const char * name, bool keep)
//{
//  vector<SGPropertyNode_ptr> children;

//  for (int pos = _children.size() - 1; pos >= 0; pos--)
//    if (compare_strings(_children[pos]->getName(), name))
//      children.push_back(removeChild(pos, keep));

//  sort(children.begin(), children.end(), CompareIndices());
//  return children;
//}


//const char *
//SGPropertyNode::getDisplayName (bool simplify) const
//{
//  _display_name = _name;
//  if (_index != 0 || !simplify) {
//    stringstream sstr;
//    sstr << '[' << _index << ']';
//    _display_name += sstr.str();
//  }
//  return _display_name.c_str();
//}


//const char *
//SGPropertyNode::getPath (bool simplify) const
//{
//  // Calculate the complete path only once.
//  if (_parent != 0 && _path.empty()) {
//    _path = _parent->getPath(simplify);
//    _path += '/';
//    _path += getDisplayName(simplify);
//  }

//  return _path.c_str();
//}

//SGPropertyNode::Type
//SGPropertyNode::getType () const
//{
//  if (_type == ALIAS)
//    return _value.alias->getType();
//  else
//    return _type;
//}


//bool
//SGPropertyNode::getBoolValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == BOOL)
//    return get_bool();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<bool>::DefaultValue;
//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getBoolValue();
//  case BOOL:
//    return get_bool();
//  case INT:
//    return get_int() == 0 ? false : true;
//  case LONG:
//    return get_long() == 0L ? false : true;
//  case FLOAT:
//    return get_float() == 0.0 ? false : true;
//  case DOUBLE:
//    return get_double() == 0.0L ? false : true;
//  case STRING:
//  case UNSPECIFIED:
//    return (compare_strings(get_string(), "true") || getDoubleValue() != 0.0L);
//  case NONE:
//  default:
//    return SGRawValue<bool>::DefaultValue;
//  }
//}

//int
//SGPropertyNode::getIntValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == INT)
//    return get_int();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<int>::DefaultValue;
//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getIntValue();
//  case BOOL:
//    return int(get_bool());
//  case INT:
//    return get_int();
//  case LONG:
//    return int(get_long());
//  case FLOAT:
//    return int(get_float());
//  case DOUBLE:
//    return int(get_double());
//  case STRING:
//  case UNSPECIFIED:
//    return atoi(get_string());
//  case NONE:
//  default:
//    return SGRawValue<int>::DefaultValue;
//  }
//}

//long
//SGPropertyNode::getLongValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == LONG)
//    return get_long();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<long>::DefaultValue;
//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getLongValue();
//  case BOOL:
//    return long(get_bool());
//  case INT:
//    return long(get_int());
//  case LONG:
//    return get_long();
//  case FLOAT:
//    return long(get_float());
//  case DOUBLE:
//    return long(get_double());
//  case STRING:
//  case UNSPECIFIED:
//    return strtol(get_string(), 0, 0);
//  case NONE:
//  default:
//    return SGRawValue<long>::DefaultValue;
//  }
//}

//float
//SGPropertyNode::getFloatValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == FLOAT)
//    return get_float();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<float>::DefaultValue;
//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getFloatValue();
//  case BOOL:
//    return float(get_bool());
//  case INT:
//    return float(get_int());
//  case LONG:
//    return float(get_long());
//  case FLOAT:
//    return get_float();
//  case DOUBLE:
//    return float(get_double());
//  case STRING:
//  case UNSPECIFIED:
//    return atof(get_string());
//  case NONE:
//  default:
//    return SGRawValue<float>::DefaultValue;
//  }
//}

//double
//SGPropertyNode::getDoubleValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == DOUBLE)
//    return get_double();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<double>::DefaultValue;

//  switch (_type) {
//  case ALIAS:
//    return _value.alias->getDoubleValue();
//  case BOOL:
//    return double(get_bool());
//  case INT:
//    return double(get_int());
//  case LONG:
//    return double(get_long());
//  case FLOAT:
//    return double(get_float());
//  case DOUBLE:
//    return get_double();
//  case STRING:
//  case UNSPECIFIED:
//    return strtod(get_string(), 0);
//  case NONE:
//  default:
//    return SGRawValue<double>::DefaultValue;
//  }
//}

//const char *
//SGPropertyNode::getStringValue () const
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == STRING)
//    return get_string();

//  if (getAttribute(TRACE_READ))
//    trace_read();
//  if (!getAttribute(READ))
//    return SGRawValue<const char *>::DefaultValue;
//  return make_string();
//}

//bool
//SGPropertyNode::setBoolValue (bool value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == BOOL)
//    return set_bool(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _tied = false;
//    _type = BOOL;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setBoolValue(value);
//    break;
//  case BOOL:
//    result = set_bool(value);
//    break;
//  case INT:
//    result = set_int(int(value));
//    break;
//  case LONG:
//    result = set_long(long(value));
//    break;
//  case FLOAT:
//    result = set_float(float(value));
//    break;
//  case DOUBLE:
//    result = set_double(double(value));
//    break;
//  case STRING:
//  case UNSPECIFIED:
//    result = set_string(value ? "true" : "false");
//    break;
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setIntValue (int value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == INT)
//    return set_int(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _type = INT;
//    _local_val.int_val = 0;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setIntValue(value);
//    break;
//  case BOOL:
//    result = set_bool(value == 0 ? false : true);
//    break;
//  case INT:
//    result = set_int(value);
//    break;
//  case LONG:
//    result = set_long(long(value));
//    break;
//  case FLOAT:
//    result = set_float(float(value));
//    break;
//  case DOUBLE:
//    result = set_double(double(value));
//    break;
//  case STRING:
//  case UNSPECIFIED: {
//    char buf[128];
//    sprintf(buf, "%d", value);
//    result = set_string(buf);
//    break;
//  }
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setLongValue (long value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == LONG)
//    return set_long(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _type = LONG;
//    _local_val.long_val = 0L;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setLongValue(value);
//    break;
//  case BOOL:
//    result = set_bool(value == 0L ? false : true);
//    break;
//  case INT:
//    result = set_int(int(value));
//    break;
//  case LONG:
//    result = set_long(value);
//    break;
//  case FLOAT:
//    result = set_float(float(value));
//    break;
//  case DOUBLE:
//    result = set_double(double(value));
//    break;
//  case STRING:
//  case UNSPECIFIED: {
//    char buf[128];
//    sprintf(buf, "%ld", value);
//    result = set_string(buf);
//    break;
//  }
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setFloatValue (float value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == FLOAT)
//    return set_float(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _type = FLOAT;
//    _local_val.float_val = 0;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setFloatValue(value);
//    break;
//  case BOOL:
//    result = set_bool(value == 0.0 ? false : true);
//    break;
//  case INT:
//    result = set_int(int(value));
//    break;
//  case LONG:
//    result = set_long(long(value));
//    break;
//  case FLOAT:
//    result = set_float(value);
//    break;
//  case DOUBLE:
//    result = set_double(double(value));
//    break;
//  case STRING:
//  case UNSPECIFIED: {
//    char buf[128];
//    sprintf(buf, "%f", value);
//    result = set_string(buf);
//    break;
//  }
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setDoubleValue (double value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == DOUBLE)
//    return set_double(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _local_val.double_val = value;
//    _type = DOUBLE;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setDoubleValue(value);
//    break;
//  case BOOL:
//    result = set_bool(value == 0.0L ? false : true);
//    break;
//  case INT:
//    result = set_int(int(value));
//    break;
//  case LONG:
//    result = set_long(long(value));
//    break;
//  case FLOAT:
//    result = set_float(float(value));
//    break;
//  case DOUBLE:
//    result = set_double(value);
//    break;
//  case STRING:
//  case UNSPECIFIED: {
//    char buf[128];
//    sprintf(buf, "%f", value);
//    result = set_string(buf);
//    break;
//  }
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setStringValue (const char * value)
//{
//                // Shortcut for common case
//  if (_attr == (READ|WRITE) && _type == STRING)
//    return set_string(value);

//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE || _type == UNSPECIFIED) {
//    clearValue();
//    _type = STRING;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setStringValue(value);
//    break;
//  case BOOL:
//    result = set_bool((compare_strings(value, "true")
//               || atoi(value)) ? true : false);
//    break;
//  case INT:
//    result = set_int(atoi(value));
//    break;
//  case LONG:
//    result = set_long(strtol(value, 0, 0));
//    break;
//  case FLOAT:
//    result = set_float(atof(value));
//    break;
//  case DOUBLE:
//    result = set_double(strtod(value, 0));
//    break;
//  case STRING:
//  case UNSPECIFIED:
//    result = set_string(value);
//    break;
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::setUnspecifiedValue (const char * value)
//{
//  bool result = false;
//  TEST_WRITE;
//  if (_type == NONE) {
//    clearValue();
//    _type = UNSPECIFIED;
//  }

//  switch (_type) {
//  case ALIAS:
//    result = _value.alias->setUnspecifiedValue(value);
//    break;
//  case BOOL:
//    result = set_bool((compare_strings(value, "true")
//               || atoi(value)) ? true : false);
//    break;
//  case INT:
//    result = set_int(atoi(value));
//    break;
//  case LONG:
//    result = set_long(strtol(value, 0, 0));
//    break;
//  case FLOAT:
//    result = set_float(atof(value));
//    break;
//  case DOUBLE:
//    result = set_double(strtod(value, 0));
//    break;
//  case STRING:
//  case UNSPECIFIED:
//    result = set_string(value);
//    break;
//  case NONE:
//  default:
//    break;
//  }

//  if (getAttribute(TRACE_WRITE))
//    trace_write();
//  return result;
//}

//bool
//SGPropertyNode::tie (const SGRawValue<bool> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  bool old_val = false;
//  if (useDefault)
//    old_val = getBoolValue();

//  clearValue();
//  _type = BOOL;
//  _tied = true;
//  _value.bool_val = rawValue.clone();

//  if (useDefault)
//    setBoolValue(old_val);

//  return true;
//}

//bool
//SGPropertyNode::tie (const SGRawValue<int> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  int old_val = 0;
//  if (useDefault)
//    old_val = getIntValue();

//  clearValue();
//  _type = INT;
//  _tied = true;
//  _value.int_val = rawValue.clone();

//  if (useDefault)
//    setIntValue(old_val);

//  return true;
//}

//bool
//SGPropertyNode::tie (const SGRawValue<long> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  long old_val = 0;
//  if (useDefault)
//    old_val = getLongValue();

//  clearValue();
//  _type = LONG;
//  _tied = true;
//  _value.long_val = rawValue.clone();

//  if (useDefault)
//    setLongValue(old_val);

//  return true;
//}

//bool
//SGPropertyNode::tie (const SGRawValue<float> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  float old_val = 0.0;
//  if (useDefault)
//    old_val = getFloatValue();

//  clearValue();
//  _type = FLOAT;
//  _tied = true;
//  _value.float_val = rawValue.clone();

//  if (useDefault)
//    setFloatValue(old_val);

//  return true;
//}

//bool
//SGPropertyNode::tie (const SGRawValue<double> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  double old_val = 0.0;
//  if (useDefault)
//    old_val = getDoubleValue();

//  clearValue();
//  _type = DOUBLE;
//  _tied = true;
//  _value.double_val = rawValue.clone();

//  if (useDefault)
//    setDoubleValue(old_val);

//  return true;

//}

//bool
//SGPropertyNode::tie (const SGRawValue<const char *> &rawValue, bool useDefault)
//{
//  if (_type == ALIAS || _tied)
//    return false;

//  useDefault = useDefault && hasValue();
//  string old_val;
//  if (useDefault)
//    old_val = getStringValue();

//  clearValue();
//  _type = STRING;
//  _tied = true;
//  _value.string_val = rawValue.clone();

//  if (useDefault)
//    setStringValue(old_val.c_str());

//  return true;
//}

//bool
//SGPropertyNode::untie ()
//{
//  if (!_tied)
//    return false;

//  switch (_type) {
//  case BOOL: {
//    bool val = getBoolValue();
//    clearValue();
//    _type = BOOL;
//    _local_val.bool_val = val;
//    break;
//  }
//  case INT: {
//    int val = getIntValue();
//    clearValue();
//    _type = INT;
//    _local_val.int_val = val;
//    break;
//  }
//  case LONG: {
//    long val = getLongValue();
//    clearValue();
//    _type = LONG;
//    _local_val.long_val = val;
//    break;
//  }
//  case FLOAT: {
//    float val = getFloatValue();
//    clearValue();
//    _type = FLOAT;
//    _local_val.float_val = val;
//    break;
//  }
//  case DOUBLE: {
//    double val = getDoubleValue();
//    clearValue();
//    _type = DOUBLE;
//    _local_val.double_val = val;
//    break;
//  }
//  case STRING:
//  case UNSPECIFIED: {
//    string val = getStringValue();
//    clearValue();
//    _type = STRING;
//    _local_val.string_val = copy_string(val.c_str());
//    break;
//  }
//  case NONE:
//  default:
//    break;
//  }

//  _tied = false;
//  return true;
//}

//SGPropertyNode *
//SGPropertyNode::getRootNode ()
//{
//  if (_parent == 0)
//    return this;
//  else
//    return _parent->getRootNode();
//}

//const SGPropertyNode *
//SGPropertyNode::getRootNode () const
//{
//  if (_parent == 0)
//    return this;
//  else
//    return _parent->getRootNode();
//}

//SGPropertyNode *
//SGPropertyNode::getNode (const char * relative_path, bool create)
//{
//  if (_path_cache == 0)
//    _path_cache = new hash_table;

//  SGPropertyNode * result = _path_cache->get(relative_path);
//  if (result == 0) {
//    vector<PathComponent> components;
//    parse_path(relative_path, components);
//    result = find_node(this, components, 0, create);
//    if (result != 0)
//      _path_cache->put(relative_path, result);
//  }

//  return result;
//}

//SGPropertyNode *
//SGPropertyNode::getNode (const char * relative_path, int index, bool create)
//{
//  vector<PathComponent> components;
//  parse_path(relative_path, components);
//  if (components.size() > 0)
//    components.back().index = index;
//  return find_node(this, components, 0, create);
//}

//const SGPropertyNode *
//SGPropertyNode::getNode (const char * relative_path) const
//{
//  return ((SGPropertyNode *)this)->getNode(relative_path, false);
//}

//const SGPropertyNode *
//SGPropertyNode::getNode (const char * relative_path, int index) const
//{
//  return ((SGPropertyNode *)this)->getNode(relative_path, index, false);
//}


//////////////////////////////////////////////////////////////////////////
//// Convenience methods using relative paths.
//////////////////////////////////////////////////////////////////////////


///**
// * Test whether another node has a value attached.
// */
//bool
//SGPropertyNode::hasValue (const char * relative_path) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? false : node->hasValue());
//}


///**
// * Get the value type for another node.
// */
//SGPropertyNode::Type
//SGPropertyNode::getType (const char * relative_path) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? UNSPECIFIED : (Type)(node->getType()));
//}


///**
// * Get a bool value for another node.
// */
//bool
//SGPropertyNode::getBoolValue (const char * relative_path,
//                  bool defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getBoolValue());
//}


///**
// * Get an int value for another node.
// */
//int
//SGPropertyNode::getIntValue (const char * relative_path,
//                 int defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getIntValue());
//}


///**
// * Get a long value for another node.
// */
//long
//SGPropertyNode::getLongValue (const char * relative_path,
//                  long defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getLongValue());
//}


///**
// * Get a float value for another node.
// */
//float
//SGPropertyNode::getFloatValue (const char * relative_path,
//                   float defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getFloatValue());
//}


///**
// * Get a double value for another node.
// */
//double
//SGPropertyNode::getDoubleValue (const char * relative_path,
//                double defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getDoubleValue());
//}


///**
// * Get a string value for another node.
// */
//const char *
//SGPropertyNode::getStringValue (const char * relative_path,
//                const char * defaultValue) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? defaultValue : node->getStringValue());
//}


///**
// * Set a bool value for another node.
// */
//bool
//SGPropertyNode::setBoolValue (const char * relative_path, bool value)
//{
//  return getNode(relative_path, true)->setBoolValue(value);
//}


///**
// * Set an int value for another node.
// */
//bool
//SGPropertyNode::setIntValue (const char * relative_path, int value)
//{
//  return getNode(relative_path, true)->setIntValue(value);
//}


///**
// * Set a long value for another node.
// */
//bool
//SGPropertyNode::setLongValue (const char * relative_path, long value)
//{
//  return getNode(relative_path, true)->setLongValue(value);
//}


///**
// * Set a float value for another node.
// */
//bool
//SGPropertyNode::setFloatValue (const char * relative_path, float value)
//{
//  return getNode(relative_path, true)->setFloatValue(value);
//}


///**
// * Set a double value for another node.
// */
//bool
//SGPropertyNode::setDoubleValue (const char * relative_path, double value)
//{
//  return getNode(relative_path, true)->setDoubleValue(value);
//}


///**
// * Set a string value for another node.
// */
//bool
//SGPropertyNode::setStringValue (const char * relative_path, const char * value)
//{
//  return getNode(relative_path, true)->setStringValue(value);
//}


///**
// * Set an unknown value for another node.
// */
//bool
//SGPropertyNode::setUnspecifiedValue (const char * relative_path,
//                     const char * value)
//{
//  return getNode(relative_path, true)->setUnspecifiedValue(value);
//}


///**
// * Test whether another node is tied.
// */
//bool
//SGPropertyNode::isTied (const char * relative_path) const
//{
//  const SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? false : node->isTied());
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<bool> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<int> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<long> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<float> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<double> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Tie a node reached by a relative path, creating it if necessary.
// */
//bool
//SGPropertyNode::tie (const char * relative_path,
//             const SGRawValue<const char *> &rawValue,
//             bool useDefault)
//{
//  return getNode(relative_path, true)->tie(rawValue, useDefault);
//}


///**
// * Attempt to untie another node reached by a relative path.
// */
//bool
//SGPropertyNode::untie (const char * relative_path)
//{
//  SGPropertyNode * node = getNode(relative_path);
//  return (node == 0 ? false : node->untie());
//}

//void
//SGPropertyNode::addChangeListener (SGPropertyChangeListener * listener,
//                                   bool initial)
//{
//  if (_listeners == 0)
//    _listeners = new vector<SGPropertyChangeListener*>;
//  _listeners->push_back(listener);
//  listener->register_property(this);
//  if (initial)
//    listener->valueChanged(this);
//}

//void
//SGPropertyNode::removeChangeListener (SGPropertyChangeListener * listener)
//{
//  vector<SGPropertyChangeListener*>::iterator it =
//    find(_listeners->begin(), _listeners->end(), listener);
//  if (it != _listeners->end()) {
//    _listeners->erase(it);
//    listener->unregister_property(this);
//    if (_listeners->empty()) {
//      vector<SGPropertyChangeListener*>* tmp = _listeners;
//      _listeners = 0;
//      delete tmp;
//    }
//  }
//}

//void
//SGPropertyNode::fireValueChanged ()
//{
//  fireValueChanged(this);
//}

//void
//SGPropertyNode::fireChildAdded (SGPropertyNode * child)
//{
//  fireChildAdded(this, child);
//}

//void
//SGPropertyNode::fireChildRemoved (SGPropertyNode * child)
//{
//  fireChildRemoved(this, child);
//}

//void
//SGPropertyNode::fireValueChanged (SGPropertyNode * node)
//{
//  if (_listeners != 0) {
//    for (unsigned int i = 0; i < _listeners->size(); i++) {
//      (*_listeners)[i]->valueChanged(node);
//    }
//  }
//  if (_parent != 0)
//    _parent->fireValueChanged(node);
//}

//void
//SGPropertyNode::fireChildAdded (SGPropertyNode * parent,
//                SGPropertyNode * child)
//{
//  if (_listeners != 0) {
//    for (unsigned int i = 0; i < _listeners->size(); i++) {
//      (*_listeners)[i]->childAdded(parent, child);
//    }
//  }
//  if (_parent != 0)
//    _parent->fireChildAdded(parent, child);
//}

//void
//SGPropertyNode::fireChildRemoved (SGPropertyNode * parent,
//                  SGPropertyNode * child)
//{
//  if (_listeners != 0) {
//    for (unsigned int i = 0; i < _listeners->size(); i++) {
//      (*_listeners)[i]->childRemoved(parent, child);
//    }
//  }
//  if (_parent != 0)
//    _parent->fireChildRemoved(parent, child);
//}



//////////////////////////////////////////////////////////////////////////
//// Simplified hash table for caching paths.
//////////////////////////////////////////////////////////////////////////

//#define HASH_TABLE_SIZE 199

//SGPropertyNode::hash_table::entry::entry ()
//  : _value(0)
//{
//}

//SGPropertyNode::hash_table::entry::~entry ()
//{
//                // Don't delete the value; we don't own
//                // the pointer.
//}

//void
//SGPropertyNode::hash_table::entry::set_key (const char * key)
//{
//  _key = key;
//}

//void
//SGPropertyNode::hash_table::entry::set_value (SGPropertyNode * value)
//{
//  _value = value;
//}

//SGPropertyNode::hash_table::bucket::bucket ()
//  : _length(0),
//    _entries(0)
//{
//}

//SGPropertyNode::hash_table::bucket::~bucket ()
//{
//  for (int i = 0; i < _length; i++)
//    delete _entries[i];
//  delete [] _entries;
//}

//SGPropertyNode::hash_table::entry *
//SGPropertyNode::hash_table::bucket::get_entry (const char * key, bool create)
//{
//  int i;
//  for (i = 0; i < _length; i++) {
//    if (!strcmp(_entries[i]->get_key(), key))
//      return _entries[i];
//  }
//  if (create) {
//    entry ** new_entries = new entry*[_length+1];
//    for (i = 0; i < _length; i++) {
//      new_entries[i] = _entries[i];
//    }
//    delete [] _entries;
//    _entries = new_entries;
//    _entries[_length] = new entry;
//    _entries[_length]->set_key(key);
//    _length++;
//    return _entries[_length - 1];
//  } else {
//    return 0;
//  }
//}

//void
//SGPropertyNode::hash_table::bucket::erase (const char * key)
//{
//  int i;
//  for (i = 0; i < _length; i++) {
//    if (!strcmp(_entries[i]->get_key(), key))
//       break;
//  }

//  if (i < _length) {
//    for (++i; i < _length; i++) {
//      _entries[i-1] = _entries[i];
//    }
//     _length--;
//  }
//}


//SGPropertyNode::hash_table::hash_table ()
//  : _data_length(0),
//    _data(0)
//{
//}

//SGPropertyNode::hash_table::~hash_table ()
//{
//  for (unsigned int i = 0; i < _data_length; i++)
//    delete _data[i];
//  delete [] _data;
//}

//SGPropertyNode *
//SGPropertyNode::hash_table::get (const char * key)
//{
//  if (_data_length == 0)
//    return 0;
//  unsigned int index = hashcode(key) % _data_length;
//  if (_data[index] == 0)
//    return 0;
//  entry * e = _data[index]->get_entry(key);
//  if (e == 0)
//    return 0;
//  else
//    return e->get_value();
//}

//void
//SGPropertyNode::hash_table::put (const char * key, SGPropertyNode * value)
//{
//  if (_data_length == 0) {
//    _data = new bucket*[HASH_TABLE_SIZE];
//    _data_length = HASH_TABLE_SIZE;
//    for (unsigned int i = 0; i < HASH_TABLE_SIZE; i++)
//      _data[i] = 0;
//  }
//  unsigned int index = hashcode(key) % _data_length;
//  if (_data[index] == 0) {
//    _data[index] = new bucket;
//  }
//  entry * e = _data[index]->get_entry(key, true);
//  e->set_value(value);
//}

//void
//SGPropertyNode::hash_table::erase (const char * key)
//{
//   if (_data_length == 0)
//    return;
//  unsigned int index = hashcode(key) % _data_length;
//  if (_data[index] == 0)
//    return;
//  _data[index]->erase(key);
//}

//unsigned int
//SGPropertyNode::hash_table::hashcode (const char * key)
//{
//  unsigned int hash = 0;
//  while (*key != 0) {
//    hash = 31 * hash + *key;
//    key++;
//  }
//  return hash;
//}

