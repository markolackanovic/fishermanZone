import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'orderBy'
})
export class OrderByPipe implements PipeTransform {

    transform(records: Array<any>, args?: any): any {
        if (records !== undefined) {
            if (records !== undefined) {
                return records.sort(function (a, b) {
                    var firstElement = a[args.property];
                    var secondElement = b[args.property];

                    if (firstElement == null || typeof firstElement === "undefined") {
                        if (args.isNumber)
                            firstElement = -1;
                        else
                            firstElement = "";
                    }
                    if (secondElement === null || typeof secondElement === "undefined") {
                        if (args.isNumber)
                            secondElement = -1;
                        else
                            secondElement = "";
                    }

                    var isBoolean = typeof firstElement === "boolean" && typeof secondElement === "boolean";
                    var isString = typeof firstElement === "string" && typeof secondElement === "string";
                    var isNumber = typeof firstElement === "number" && typeof secondElement === "number";

                    if (isBoolean || isNumber) {
                        if (firstElement < secondElement) { //Sort booleans
                            return -1 * args.direction;
                        } else if (firstElement > secondElement) {
                            return 1 * args.direction;
                        } else {
                            return 0;
                        }
                    } else if (isString) {
                        var isFirstNum = /^\d+$/.test(firstElement);
                        var isSecondNum = /^\d+$/.test(secondElement);

                        if (!isNaN(parseInt(firstElement)) && !isNaN(parseInt(secondElement)) && isFirstNum && isSecondNum) { //Convert string to number if code
                            firstElement = parseInt(firstElement);
                            secondElement = parseInt(secondElement);

                            if (firstElement < secondElement) { //Sort string as numbers
                                return -1 * args.direction;
                            } else if (firstElement > secondElement) {
                                return 1 * args.direction;
                            } else {
                                return 0;
                            }
                        } else {
                            if (firstElement.localeCompare(secondElement) < 0) //Sort strings
                                return -1 * args.direction;
                            else if (firstElement.localeCompare(secondElement) > 0)
                                return 1 * args.direction;
                            else
                                return 0;
                        }
                    }

                    return 0;
                });
            }
            return records;
        }
    }
}
