﻿import React from 'react';

const Chooser = (props) => (
        <div className="col-xs-12 col-sm-12 example-col">
            <label>
                {props.label}:
                <select
                    style={{ width: 250, marginLeft: 10 }}
                    value={props.value}
                    onChange={props.onChange}
                >
                    { props.options.map((option, key) => <option key={key} value={option}>{option}</option>) }
                </select>
            </label>
    </div>
);

export { Chooser };
