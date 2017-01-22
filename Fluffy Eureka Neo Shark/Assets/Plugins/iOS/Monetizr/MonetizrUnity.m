//
//  MonetizrUnity.m
//  Monetizr
//
//  Created by Ben Thornburg on 11/17/16.
//  Copyright © 2016 TheMonetizr. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Monetizr.h"

// Unity wrapper for show product function
extern void _ShowProductWithID(const char* productID, int numPairs, const char* pKeyValues[])
{
    // be sure a product ID was provided and convert it to NSString
    if (productID == NULL) return;
    NSString *nativeID = [NSString stringWithUTF8String:productID];

    // create dictionary
    NSMutableDictionary *dict = [[NSMutableDictionary alloc] init];

    // read each key/value pair and create a settings dictionary
    for (int i = 0; i < numPairs; i++)
    {
        // convert C strings to NSString
        if ((pKeyValues[i*2] == NULL) || (pKeyValues[i*2+1] == NULL)) return;
        NSString *keyString = [NSString stringWithUTF8String:pKeyValues[i*2]];
        NSString *valueString = [NSString stringWithUTF8String:pKeyValues[i*2+1]];

        // assign new value in plist
        [dict setObject:valueString forKey:keyString];
    }

    // Show Product using this settings dictionary
    [Monetizr showProductWithID:nativeID usingDict:dict];
}
