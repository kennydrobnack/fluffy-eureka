//
//  Monetizr.m
//  m2048
//
//  Created by Armands Avotins on 09/05/16.
//  Copyright © 2016 TheMonetizr. All rights reserved.
//

#import "Monetizr.h"

@implementation Monetizr

+ (void) showProductWithID:(NSString *)productID
{
    [Monetizr showProductWithID:productID usingDict:nil];
}

+ (void) showProductWithID: (NSString *) productID usingDict:(NSDictionary *)settingsDict
{
    // Read properties from given dictionary
    NSDictionary *dict = settingsDict;

    // If dictionary wasn't specified, read from file instead
    if (settingsDict == nil)
    {
        NSString *path = [[NSBundle mainBundle] pathForResource:@"Monetizr" ofType:@"plist"];
        dict = [NSDictionary dictionaryWithContentsOfFile:path];
    }

    // Don't continue if dev values aren't set
    if (dict == nil) return;

    // Read Monetizr properties
    NSString *shopDomain = [dict valueForKey:@"shopDomain"];
    NSString *apiKey = [dict valueForKey:@"apiKey"];
    NSString *channelId = [dict valueForKey:@"channelId"];
    NSString *applePayMerchantId = [dict valueForKey:@"applePayMerchantId"];

    // Init BUY client
    BUYClient *client = [[BUYClient alloc] initWithShopDomain:shopDomain
                                                       apiKey:apiKey
                                                    channelId:channelId];

    BUYTheme *theme = [BUYTheme new];
    [theme setTintColor:[UIColor orangeColor]];
    [theme setShowsProductImageBackground:YES];

    // Determ product variant to choose by default
    NSString *deviceName = [Monetizr deviceName];


    [client getProductById:productID completion:^(BUYProduct *product, NSError *error) {
        if (error) {
            NSLog(@"Error retrieving product: %@", error.userInfo);
        } else {
            BUYProductViewController *productViewController = [[BUYProductViewController alloc] initWithClient:client theme:theme];

            [productViewController setMerchantId:applePayMerchantId];
            [productViewController loadWithProduct:product forDevice:deviceName completion:NULL];

            UIViewController *topRootViewController = [UIApplication sharedApplication].keyWindow.rootViewController;
            while (topRootViewController.presentedViewController)
            {
                topRootViewController = topRootViewController.presentedViewController;
            }

            [topRootViewController presentViewController:productViewController animated:YES completion:nil];

        }
    }];
}

+ (NSString*) deviceName
{
    struct utsname systemInfo;

    uname(&systemInfo);

    NSString* code = [NSString stringWithCString:systemInfo.machine
                                        encoding:NSUTF8StringEncoding];

    static NSDictionary* deviceNamesByCode = nil;

    if (!deviceNamesByCode) {

        deviceNamesByCode = @{@"i386"      :@"Simulator",
                              @"x86_64"    :@"Simulator",

                              // Models list
                              @"iPhone5,3"	:@"iPhone 5c",
                              @"iPhone5,4"	:@"iPhone 5c",
                              @"iPhone6,1"	:@"iPhone 5/5s/SE",
                              @"iPhone6,2"	:@"iPhone 5/5s/SE",
                              @"iPhone7,1"	:@"iPhone 6/6s Plus",
                              @"iPhone7,2"	:@"iPhone 6/6s",
                              @"iPhone8,1"	:@"iPhone 6/6s",
                              @"iPhone8,2"	:@"iPhone 6/6s Plus",
                              @"iPad1,1"	:@"iPad",
                              @"iPad2,1"	:@"iPad 2",
                              @"iPad2,2"	:@"iPad 2",
                              @"iPad2,3"	:@"iPad 2",
                              @"iPad2,4"	:@"iPad 2",
                              @"iPad2,5"	:@"iPad mini",
                              @"iPad2,6"	:@"iPad mini",
                              @"iPad2,7"	:@"iPad mini",
                              @"iPad3,1"	:@"iPad (3rd gen)",
                              @"iPad3,2"	:@"iPad (3rd gen)",
                              @"iPad3,3"	:@"iPad (3rd gen)",
                              @"iPad3,4"	:@"iPad (4th gen)",
                              @"iPad3,5"	:@"iPad (4th gen)",
                              @"iPad3,6"	:@"iPad (4th gen)",
                              @"iPad4,1"	:@"iPad Air",
                              @"iPad4,2"	:@"iPad Air",
                              @"iPad4,3"	:@"iPad Air",
                              @"iPad4,4"	:@"iPad mini 2",
                              @"iPad4,5"	:@"iPad mini 2",
                              @"iPad4,6"	:@"iPad mini 2",
                              @"iPad4,7"	:@"iPad mini 3",
                              @"iPad4,8"	:@"iPad mini 3",
                              @"iPad4,9"	:@"iPad mini 3",
                              @"iPad5,1"	:@"iPad mini 4",
                              @"iPad5,2"	:@"iPad mini 4",
                              @"iPad5,3"	:@"iPad Air 2",
                              @"iPad5,4"	:@"iPad Air 2",
                              @"iPad6,7"	:@"iPad Pro",
                              @"iPad6,8"	:@"iPad Pro",
                              @"iPod1,1"	:@"iPod touch",
                              @"iPod2,1"	:@"iPod touch (2nd gen)",
                              @"iPod3,1"	:@"iPod touch (3rd gen)",
                              @"iPod4,1"	:@"iPod touch (4th gen)",
                              @"iPod5,1"	:@"iPod touch (5th gen)",
                              @"iPod7,1"	:@"iPod touch (6th gen)"
                              };
    }

    NSString* deviceName = [deviceNamesByCode objectForKey:code];

    if (!deviceName) {
        // Not found on database. At least guess main device type from string contents:

        if ([code rangeOfString:@"iPod"].location != NSNotFound) {
            deviceName = @"Unknown";
        }
        else if([code rangeOfString:@"iPad"].location != NSNotFound) {
            deviceName = @"Unknown";
        }
        else if([code rangeOfString:@"iPhone"].location != NSNotFound){
            deviceName = @"Unknown";
        }
        else {
            deviceName = @"Unknown";
        }
    }
    
    return deviceName;
}
@end
