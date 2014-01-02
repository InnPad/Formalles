{
    data: [
        {
            "@metadata": {
                Key: "Type"
            },
            Name: "Type"
        },
        {
            "@metadata": {
                Key: "Type/Object"
            },
            Embeddable: true,
            Name: "Object",
            Summary: {
                "en": "Any object, no validation is performed."
            },
            Title: {
                "en": "Object",
                "es": "Objeto"
            }
        },
        {
            "@metadata": {
                Key: "Type/Item"
            },
            Name: "Item"
        },
        {
            "@metadata": {
                Key: "Type/Model"
            },
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
                Key: "Type/Model/2da80b1d-2587-494c-94f5-926e99101dbb"
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
                Key: "Type/Model/32bdf17f-4578-436c-8b2c-601d507bb856"
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
                Key: "Type/Model/1497517e-1542-4cde-abe5-b9346b6dc478"
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
                Key: "Type/Model/45ac1eda-04d2-4f9a-b075-514340ddf158"
            },
            Embeddable: true,
            Name: "Validation"
        },
        {
            "@metadata": {
                Key: "Type/Text"
            },
            Embeddable: true,
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
        }
    ]
}