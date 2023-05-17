import { Pipe, PipeTransform } from '@angular/core';
import { LanguageService } from '../../core/language/language.service';

@Pipe({ name: 'translate' })
export class TranslatePipe implements PipeTransform {
  constructor(private _languageService: LanguageService) { }

  transform(value: string, args: any[] = []): any {
    // prevents the application from breaking if the object doesn't exist yet
    if (!value) {
      return null;
    }

    // this will return translated object
    return this._languageService.instant(value);
  }
}
