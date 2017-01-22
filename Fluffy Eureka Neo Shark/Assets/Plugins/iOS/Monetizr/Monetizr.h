//
//  Monetizr.h
//  m2048
//
//  Created by Armands Avotins on 09/05/16.
//  Copyright © 2016 TheMonetizr. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Buy.h"
#import <sys/utsname.h>

@interface Monetizr : UIViewController

+ (void) showProductWithID: (NSString *) productID;
+ (void) showProductWithID: (NSString *) productID usingDict:(NSDictionary *)settingsDict;

@end
