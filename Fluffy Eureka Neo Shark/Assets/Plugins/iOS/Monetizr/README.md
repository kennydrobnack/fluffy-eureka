[![GitHub license](https://img.shields.io/badge/license-MIT-lightgrey.svg)](todo)
[![GitHub release](https://img.shields.io/badge/build-1.0.0-blue.svg)](https://github.com/Shopify/mobile-buy-sdk-ios/releases)

# TheMonetizr SDK for iOS
TheMonetizr SDK makes it simple to sell physical products inside your mobile app. With a few lines of code, you can let your users buy products using Apple Pay or their credit card.

TheMonetizr SDK includes modified Shopify’s Mobile Buy SDK distributed under MIT license

### Documentation
Official documentation can be found on the [TheMonetizr website](http://themonetizr.com).

### Installation
<a href="https://github.com/themonetizr/The-Monetizr-SDK">Download TheMonetizr</a>

Add Monetizr-SDK to your Xcode project.

### Quick Start

* Import the header

```objc
#import "Monetizr.h";
```
* Setup and enable Apple Pay in your project (Optional)

Find setup instructions on [Apple developer website](https://developer.apple.com/apple-pay/) and [The Monetizr website](http://themonetizr.com/implementation/). Use Certificate Signing Request (CSR) provided by TheMonetizr.

* Configure Monetizr.plist

```objc
@{
    @"applePayMerchantId": @"", // Optional
    @"channelId": @"", // Provided by TheMonetizr
    @"shopDomain": @"", // Provided by TheMonetizr
    @"apiKey": @"", // Provided by TheMonetizr  
};
```

* To open product view

```objc
[Monetizr showProductWithID:@"Provided product ID"]
```

### Help

For help, please contact [TheMonetizr](http://themonetizr.com).

### License

TheMonetizr SDK is provided under an MIT Licence.  See the [LICENSE](LICENSE) file
