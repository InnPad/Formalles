{
    data: [
        {
            "@metadata": {
                Key: "Type/Model/2da80b1d-2587-494c-94f5-926e99101dbb",
                Type: "Model"
            },
            Embeddable: true,
            Name: "Action",
            Fields: {
                Title: {
                    Type: "Text"
                },
                Summary: {
                    Type: "Text"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/32bdf17f-4578-436c-8b2c-601d507bb856",
                Type: "Model"
            },
            Embeddable: true,
            Name: "Field",
            Fields: {
                "Auto": {
                    Type: "Boolean"
                },
                "Constraint": {
                    Type: "Object"
                },
                "HasMany": {
                    Type: "Boolean"
                },
                "Title": {
                    Type: "Text"
                },
                "Type": {
                    Type: "String"
                },
                "Summary": {
                    Type: "Text"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/cae9abbc-be51-4e7f-b3b3-ff9e475d24b9",
                Type: "Model"
            },
            BaseType: "Type",
            Name: "Item"
        },
        {
            "@metadata": {
                Key: "Type/Model/5562a000-e666-4d65-b012-42e238c0a5b7",
                Type: "Model"
            },
            BaseType: "Type",
            Name: "Text",
            Fields: {
                "en": {
                    Type: "String"
                },
                "es": {
                    Type: "String"
                },
                "jp": {
                    Type: "String"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/4bfc8aaf-1fac-4263-8859-12a781aad8a8",
                Type: "Model"
            },
            Name: "Type"
        },
        {
            "@metadata": {
                Key: "Type/Model/1497517e-1542-4cde-abe5-b9346b6dc478",
                Type: "Model"
            },
            Embeddable: true,
            Name: "Section",
            Fields: {
                "Title": {
                    "Type": "Text"
                },
                "Summary": {
                    "Type": "Text"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/9ebcc44f-a950-4d0a-82c6-d999988bd69e",
                Type: "Model"
            },
            BaseType: "Type",
            Name: "Model",
            Fields: {
                Actions: {
                    HasMany: true,
                    Type: "Action"
                },
                Fields: {
                    HasMany: true,
                    Type: "Field"
                },
                Sections: {
                    HasMany: true,
                    Type: "Section"
                },
                Summary: {
                    Type: "Text"
                },
                Title: {
                    Type: "Text"
                }
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/45ac1eda-04d2-4f9a-b075-514340ddf158",
                Type: "Model"
            },
            BaseType: "Type",
            Name: "Object",
            Summary: {
                "en": "Dynamic object, no validation is performed."
            },
            Title: {
                "en": "Object",
                "es": "Objeto"
            }
        },
        {
            "@metadata": {
                Key: "Type/Model/",
                Type: "Model"
            },
            Name: "Validation"
        },
        {
            "@metadata": {
                Key: "Type/Model/1fd4434c-97c0-4a12-bb06-fbe0a79e08c7",
                Type: "Model"
            },
            BaseType: "Type",
            Name: "Value",
            Fields: {
                "Auto": {
                    Constraints: {
                        // ensure unit field is selected
                        "UnitField": true
                    },
                    Summary: {
                        "en": "Auto convert on UnitField selection change".
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
    ]
}