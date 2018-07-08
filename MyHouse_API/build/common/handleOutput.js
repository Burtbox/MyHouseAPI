"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var chalk_1 = require("chalk");
var logger_1 = require("./logger");
exports.handleOutput = function () {
    var output = function (error, stdout, stderr) {
        if (error) {
            logger_1.default.error(chalk_1.default.red.bold.underline("exec error:") + error);
        }
        if (stderr) {
            logger_1.default.error(chalk_1.default.red("Error: ") + stderr);
        }
    };
};
//# sourceMappingURL=handleOutput.js.map