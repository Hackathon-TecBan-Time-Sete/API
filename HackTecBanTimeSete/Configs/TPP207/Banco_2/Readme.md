# Readme file for TPP207 

## Client Details 
 clientID=fbcca164-b45b-4ed9-9223-ac272e796364 
 clientSecret=e7cd4d0a-136b-42d0-b962-5769cc5f2cd2 

## Organisation Details 
 orgName=TPP207 
 orgID=0fa1ee96-c45c-4b44-983d-e9478205c512 

## Software Details 
 softwareName=TPP207 
 softwareID=4edb911b-4ecb-4b35-8ad6-077c91009894 

## Cert KID Details 
 transportKID=rUSuK2tAs1NyvRGVf1GgQwkbpXL3rpacN5EcVSA3Rvk 
 signingKID=yF8Laq2mVzwuJQt7MHP3N_Q18aQ8yUECkRjDj7nJDZU 

## Cert Pem Details 
 transportPEM=https://tecban-uat-us-east-1-keystore.s3.amazonaws.com/0fa1ee96-c45c-4b44-983d-e9478205c512/4edb911b-4ecb-4b35-8ad6-077c91009894/rUSuK2tAs1NyvRGVf1GgQwkbpXL3rpacN5EcVSA3Rvk.pem 
 signingPEM=https://tecban-uat-us-east-1-keystore.s3.amazonaws.com/0fa1ee96-c45c-4b44-983d-e9478205c512/4edb911b-4ecb-4b35-8ad6-077c91009894/yF8Laq2mVzwuJQt7MHP3N_Q18aQ8yUECkRjDj7nJDZU.pem 

## Server Details 
 Well Known Endpoint=https://auth2.tecban-sandbox.o3bank.co.uk/.well-known/openid-configuration 
 Token Endpoint=https://as2.tecban-sandbox.o3bank.co.uk/token 
 Resource Endpoint=https://rs2.tecban-sandbox.o3bank.co.uk 
 Auth Endpoint=https://auth2.tecban-sandbox.o3bank.co.uk/auth 

 ## User & Account Details 
 [
  {
    "username": "team207b2u1",
    "password": "794093",
    "accounts": [
      {
        "accountNumber": "02207001001"
      },
      {
        "accountNumber": "02207001002"
      },
      {
        "accountNumber": "02207001003"
      }
    ]
  },
  {
    "username": "team207b2u2",
    "password": "712979",
    "accounts": [
      {
        "accountNumber": "02207002001"
      },
      {
        "accountNumber": "02207002002"
      },
      {
        "accountNumber": "02207002003"
      }
    ]
  },
  {
    "username": "team207b2u3",
    "password": "458441",
    "accounts": [
      {
        "accountNumber": "02207003001"
      },
      {
        "accountNumber": "02207003002"
      },
      {
        "accountNumber": "02207003003"
      }
    ]
  },
  {
    "username": "team207b2u4",
    "password": "534233",
    "accounts": [
      {
        "accountNumber": "02207004001"
      },
      {
        "accountNumber": "02207004002"
      },
      {
        "accountNumber": "02207004003"
      }
    ]
  },
  {
    "username": "team207b2u5",
    "password": "861369",
    "accounts": [
      {
        "accountNumber": "02207005001"
      },
      {
        "accountNumber": "02207005002"
      },
      {
        "accountNumber": "02207005003"
      }
    ]
  }
] 

## Tip for testing in postman 
 In postman settings - certificates tab - add the transport cert and key for the rs and token endpoints 

