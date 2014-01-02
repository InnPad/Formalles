{
    data: [
        {
            "@metadata": {
                Key: "Type/Value"
            },
            BaseType: "Type",
            Name: "Value",
            Fields: {
                "Auto": {
                    Constraint: {
                        "UnitField": true
                    },
                    Summary: {
                        "en": "Auto convert on UnitField selection change"
                    },
                    Type: "Boolean",
                },
                "Unit": {
                    Summary: {
                        "en": "Unit type of the value. If UnitField is specified, this is the default."
                    },
                    Type: "String",
                },
                "UnitField": {
                    Summary: {
                        "en": "Name of the unit field"
                    },
                    Type: "String"
                },
                "Validations": {
                    HasMany: true,
                    Type: "Validation"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/String"
            },
            Name: "String",
            Title: {
                "en": "Unicode character string.",
                "es": "Cadena de caracteres unicode."
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/String/ASCII"
            },
            Name: "String/ASCII",
            Summary: {
                "en": "ASCII character string",
                "es": "Cadena de caracteres en ASCII"
            },
            Validations: {
                "AlphaNumeric": {
                    Type: "Format",
                    Format: "xxx.+xxx"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number"
            },
            Name: "Number",
            Title: {
                "en": "Number",
                "es": "Numero"
            },
            Validations: {
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Binary"
            },
            Name: "Number/Binary",
            Unit: "Unit/Radix/2",
            Title: {
                "en": "Binary",
                "es": "Binario"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal"
            },
            Fields: {
                "Length": {
                },
                "Precision": {
                },
                "Scale": {
                }
            },
            Name: "Number/Decimal",
            Unit: "Unit/Radix/10",
            Title: {
                "en": "Decimal",
                "es": "Decimal"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal/Double"
            },
            Name: "Number/Decimal/Double",
            Length: 8,
            Precision: 16,
            Scale: 308,
            Unit: "Unit/Radix/10",
            Title: {
                "en": "Double",
                "es": "Doble"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal/Float"
            },
            BaseType: "Number/Decimal",
            Name: "Number/Decimal/Float",
            Length: 4,
            Precision: 7,
            Scale: 38,
            Unit: "Unit/Radix/10",
            Title: {
                "en": "Float",
                "es": "Flotante"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal/Int32"
            },
            BaseType: "Number/Decimal",
            Name: "Number/Decimal/Int32",
            Length: 4,
            Precision: 10,
            Scale: 0,
            Unit: "Unit/Radix/10",
            Title: {
                "en": "Integer 32bits",
                "es": "Entero 32bits"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal/Int16"
            },
            BaseType: "Number/Decimal",
            Name: "Number/Decimal/Int16",
            Length: 2,
            Precision: 5,
            Scale: 0,
            Unit: "Unit/Radix/10",
            Title: {
                "en": "Integer 16bits",
                "es": "Entero 16bits"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Hexadecimal"
            },
            Name: "Number/Hexadecimal",
            Unit: "Unit/Radix/16",
            Title: {
                "en": "Hexadecimal",
                "es": "Hexadecimal"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Octal"
            },
            Name: "Number/Octal",
            Unit: "Unit/Radix/8",
            Title: {
                "en": "Octal",
                "es": "Binario"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Base64"
            },
            Name: "Number/Base64",
            Unit: "Unit/Radix/64",
            Title: {
                "en": "Base 64",
                "es": "Base 64"
            }
        },
        {
            "@metadata": {
                Key: "Type/Value/Number/Decimal/Money"
            },
            Name: "Money",
            Title: {
                "en": "Money",
                "es": "Dinero"
            },
            Validations: {
            }
        }
    ]
}