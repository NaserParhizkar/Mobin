﻿import React from 'react';
import { registerForIntl, provideIntlService } from '@progress/kendo-react-intl';

class DateFormatter extends React.Component {
    render() {
        return (
            <div className="col-xs-12 col-sm-6 example-col">
                <label>Locale date:</label> {provideIntlService(this).formatDate(new Date(2000, 10, 6), 'EEEE, d.MM.y')}
            </div>
        );
    }
}

registerForIntl(DateFormatter);

export { DateFormatter };
