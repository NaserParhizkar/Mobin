import React from 'react';
import ReactDOM from 'react-dom';

/* CLDR Data */

import likelySubtags from 'cldr-core/supplemental/likelySubtags.json';
import currencyData from 'cldr-core/supplemental/currencyData.json';
import weekData from 'cldr-core/supplemental/weekData.json';

import bgNumbers from 'cldr-numbers-full/main/bg/numbers.json';
import bgLocalCurrency from 'cldr-numbers-full/main/bg/currencies.json';
import bgCaGregorian from 'cldr-dates-full/main/bg/ca-gregorian.json';
import bgDateFields from 'cldr-dates-full/main/bg/dateFields.json';

import usNumbers from 'cldr-numbers-full/main/en/numbers.json';
import usLocalCurrency from 'cldr-numbers-full/main/en/currencies.json';
import usCaGregorian from 'cldr-dates-full/main/en/ca-gregorian.json';
import usDateFields from 'cldr-dates-full/main/en/dateFields.json';

import gbNumbers from 'cldr-numbers-full/main/en-GB/numbers.json';
import gbLocalCurrency from 'cldr-numbers-full/main/en-GB/currencies.json';
import gbCaGregorian from 'cldr-dates-full/main/en-GB/ca-gregorian.json';
import gbDateFields from 'cldr-dates-full/main/en-GB/dateFields.json';

import faNumbers from 'cldr-numbers-full/main/fa/numbers.json';
import faLocalCurrency from 'cldr-numbers-full/main/fa/currencies.json';
import faCaGregorian from 'cldr-dates-full/main/fa/ca-gregorian.json';
import faDateFields from 'cldr-dates-full/main/fa/dateFields.json';


import { IntlProvider, load } from '@progress/kendo-react-intl';
import { DateFormatter } from './DateFormatter';
import { CurrencyFormatter } from './CurrencyFormatter';
import { Chooser } from './Chooser';

load(
    likelySubtags,
    currencyData,
    weekData,
    bgNumbers,
    bgLocalCurrency,
    bgCaGregorian,
    bgDateFields,
    usNumbers,
    usLocalCurrency,
    usCaGregorian,
    usDateFields,
    gbNumbers,
    gbLocalCurrency,
    gbCaGregorian,
    gbDateFields,
    faNumbers,
    faLocalCurrency,
    faCaGregorian,
    faDateFields
);
const locales = ['en-US', 'bg-BG', 'en-GB', 'fa'];


class App extends React.Component {
    state = { locale: 'en' };

    render() {
        const { locale } = this.state;
        return (
            <IntlProvider locale={locale}>
                <div className="example-wrapper row">
                    <Chooser value={locale} onChange={this.onChange} options={locales} label="Select locale" />
                    <DateFormatter />
                    <CurrencyFormatter />
                </div>
            </IntlProvider>
        );
    }

    onChange = (event) => {
        this.setState({ locale: event.target.value });
    }
}


export default App;
