# TheMonetizr Unity Asset for iOS
TheMonetizr Unity Asset makes it simple to sell physical products inside your mobile app. With one prefab, you can let your users buy products using Apple Pay or their credit card.

TheMonetizr SDK includes modified Shopify’s Mobile Buy SDK distributed under MIT license

### Documentation
Official documentation can be found on the [TheMonetizr website](http://themonetizr.com).

### Installation
Add Monetizr Unity Asset to your Unity project.

Note: The required Shopify Mobile Buy SDK requires a minimum build target of iOS 8.0. Be sure to change this in your build settings!

### Quick Start

* Add TheMonetizr prefab (in the Monetizr folder) to your first scene.

* Fill in the Channel ID, Shop Domain, and the API Key with the values provided by TheMonetizr. If using Apple Pay, fill in the Apple Pay Merchant ID and follow the instructions below for enabling Apple Pay in Xcode.

* To show the product page, call the ShowProductWithID function. For an example of this, check out the demo project.

* To show the product page from code, call the function like this:

Monetizr.Instance.ShowProductWithID("7155284231");

* Setup and enable Apple Pay in your project (Optional)

Find setup instructions on [Apple developer website](https://developer.apple.com/apple-pay/) and [The Monetizr website](http://themonetizr.com/implementation/). Use Certificate Signing Request (CSR) provided by TheMonetizr.

### Help

For help, please contact [TheMonetizr](http://themonetizr.com).

### License

TheMonetizr SDK is provided under an MIT Licence.  See the [LICENSE](LICENSE) file
