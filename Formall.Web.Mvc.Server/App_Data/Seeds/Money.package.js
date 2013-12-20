{
    data: [
        {
            "@metadata": {
                Key: "Type/Model/511a8a21-9111-4dc7-aa4d-7b5e320ea7a0",
                Type: "Model"
            },
            BaseType: "Unit",
            Name: "Currency",
            Fields: {
                "ISO4217": {
                    Required: true,
                    Type: "String"
                },
                "Symbol": {
                    Required: true,
                    Type: "String"
                }
            },
            Summary: {
                "en": "Currency Type",
                "es": "Tipo de Moneda"
            },
            Title: {
                "en": "Currency",
                "es": "Moneda"
            }
        },
        {
            "@metadata": {
                Key: "Type/Unit/Currency/049a37a0-6d58-4ca2-a028-07cb898b5b10",
                Type: "Currency"
            },
            BaseType: "Currency",
            Name: "Currency/EUR",
            ISO4217: "EUR",
            Rank: 2,
            Symbol: "€",
            Title: {
                "en": "Euro",
                "es": "Euro"
            }
        },
        {
            "@metadata": {
                Key: "Type/Unit/Currency/46480544-e901-4887-8e37-399fae0f4dce",
                Type: "Currency"
            },
            BaseType: "Currency",
            Name: "Currency/JPY",
            ISO4217: "JPY",
            Rank: 2,
            Symbol: "¥",
            Title: {
                "en": "Japanese Yen",
                "es": "Yen Japones"
            }
        },
        {
            "@metadata": {
                Key: "Type/Unit/Currency/6c0edc24-4fab-4a07-85bb-4c57b7a68a41",
                Type: "Currency"
            },
            BaseType: "Currency",
            Name: "Currency/GBP",
            ISO4217: "GBP",
            Rank: 4,
            Symbol: "£",
            Title: {
                "en": "Pound sterling",
                "es": "Libra esterlina"
            }
        },
        {
            "@metadata": {
                Key: "Type/Unit/Currency/a3e25a36-18b7-4d5a-bfa8-d7162266bc31",
                Type: "Currency"
            },
            BaseType: "Currency",
            Name: "Currency/USD",
            ISO4217: "USD",
            Rank: 1,
            Symbol: "$",
            Title: {
                "en": "United State Dollar",
                "es": "Dollar Esdadounidense"
            }
        }
    ]
}