using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Auto.Test.Tool;
using System.Threading;
using Auto.Test.Org.Core.Driver;

namespace Auto.Test.Tool.Core
{
    class SeleniumJavaScriptActions : DriverManager
    {
        private static int gblTimeout = 60;
        private static long timelaps = 500;
        private static int actionCounter = 0;
        public static string Set(string target, string value)
        {
            return doAction(ActionKeywords.SET, target, value);
        }
        public static string Select(string target, string value)
        {
            return doAction(ActionKeywords.SELECT, target, value);
        }
        public static string Click(string target)
        {
            return doAction(ActionKeywords.CLICK, target, "");
        }
        public static string Verify(string target, string value)
        {
            return doAction(ActionKeywords.VERIFY, target, value);
        }
        public static string Change(string target, string value)
        {
            return doAction(ActionKeywords.CHANGE, target, value);
        }
        public static string Store(string target)
        {
            return doAction(ActionKeywords.STORE, target, "");
        }
        public static string Test(string target)
        {
            return doAction(ActionKeywords.TEST, target, "");
        }

        private static string doAction(string action, string target, string value)
        {
            string retval = "";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            retval = (string)js.ExecuteScript(GetActionScript(action, target, value));
            if (retval != "")
            {
                if (actionCounter < gblTimeout)
                {
                    try
                    {
                        actionCounter++;
                        Thread.Sleep(1000);
                        retval = doAction(action, target, value);
                    }
                    catch (Exception e)
                    {
                        // TODO: handle exception
                    }
                }
            }
            else
                actionCounter = 0;
            return retval;
        }
        private static string GetActionScript(string action, string target, string value)
        {

            return @"return doAction('" + action + "','" + target + "','" + value + "');function doAction(cmd, tar, val){\n" +
              "    var errStack = {\n" +
              "\n" +
              "\n" +
              "        SELECTOR_HLEP_SELECTOR_CONDITIONS: function (some) {\n" +
              "            return 'input[type\\:\\=text],not[class\\:\\=form-control],[placeholder\\:\\=enter userid]) \\n\\t return elemnts match with ' + some + ' tagname <input> with type as text and not having class as form-control and prperty as placeholder as enter userid';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_ID: function () {\n" +
              "            return '\\n ID: use #(someid_conditions) \\n EXAMPLE:\\n\\t #(user_id)  \\n\\t returns element id as user_id \\n\\t #(userid::form::action,' + errStack.SELECTOR_HLEP_SELECTOR_CONDITIONS('id as userid::form::action and');\n" +
              "        },\n" +
              "        SELECTOR_HLEP_CLASS: function () {\n" +
              "            return '\\n CLASS: use .(someclass_conditions) \\n EXAMPLE:\\n\\t .(ng-class) \\n\\t return element class as ng-class \\n\\t .(form-control,' + errStack.SELECTOR_HLEP_SELECTOR_CONDITIONS('class as form-control and');\n" +
              "        },\n" +
              "        SELECTOR_HLEP_NAME: function () {\n" +
              "            return '\\n NAME: use n(somename_conditions) \\n EXAMPLE:\\n\\t n(form_city_name) \\n\\t return element name as  form_city_name \\n\\t n(firstname,' + errStack.SELECTOR_HLEP_SELECTOR_CONDITIONS('name as firstname and');\n" +
              "        },\n" +
              "        SELECTOR_HLEP_XPATH: function () {\n" +
              "            return '\\n XPATH: use x(somexpath_conditions) \\n EXAMPLE:\\n\\t x(/*div[id=userid]) \\n\\t return elements match with tagname <div> and id property as userid';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_ELEMENT: function () {\n" +
              "            return '\\n ELEMENT: use e(someeelment_conditions) \\n EXAMPLE:\\n\\t e(' + errStack.SELECTOR_HLEP_SELECTOR_CONDITIONS('');\n" +
              "        },\n" +
              "        SELECTOR_HLEP_TEXT: function () {\n" +
              "            return '\\n TEXT: use t(sometext_conditions) \\n EXAMPLE:\\n\\t t(userid:) \\n\\t return elemnts having test as userid:';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_PARENT: function () {\n" +
              "            return '\\n PARENT: use p(someparent_conditions) \\n EXAMPLE:\\n\\t t(tr) \\n\\t return Immediate parent node with tagname as <tr> \\n\\t t(div,[class\\:\\=form-control]) \\n\\t return Immediate parent node with tagname as <div> and class name as form-control';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_CHILD: function () {\n" +
              "            return '\\n CHILD: use c(somechild_conditions) \\n EXAMPLE:\\n\\t c(tr) \\n\\t return all child nodes with tagname as <tr> \\n\\t c(div,[class\\:\\=form-control]) \\n\\t return all child nodes tagname as <div> and class name as form-control';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_COUNT: function () {\n" +
              "            return '\\n COUNT: use count() \\n EXAMPLE:\\n\\t count() \\n\\t return total count of the filtered elements';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_INDEX: function () {\n" +
              "            return '\\n INDEX: use i(somexpath_conditions) \\n EXAMPLE:\\n\\t i(first) \\n\\t return first index item from before filter objects \\n\\t i(last) \\n\\t return last index item from before filter objects \\n\\t i(2) \\n\\t return 2nd index item from before filter objects';\n" +
              "        },\n" +
              "        SELECTOR_HLEP_GET: function () {\n" +
              "            return '\\n GET: use g(getoptions_conditions) EXAMPLE:\\n\\t g(text) \\n\\t return text from filtered object';\n" +
              "        },\n" +
              "        SELECTOR_HLEP: function () {\n" +
              "            return 'SELECTORS HELP: use below format for selectors'\n" +
              "            + errStack.SELECTOR_HLEP_ID()\n" +
              "            + errStack.SELECTOR_HLEP_CLASS()\n" +
              "            + errStack.SELECTOR_HLEP_NAME()\n" +
              "            + errStack.SELECTOR_HLEP_XPATH()\n" +
              "            + errStack.SELECTOR_HLEP_ELEMENT()\n" +
              "            + errStack.SELECTOR_HLEP_TEXT()\n" +
              "            + errStack.SELECTOR_HLEP_PARENT()\n" +
              "            + errStack.SELECTOR_HLEP_CHILD()\n" +
              "            + errStack.SELECTOR_HLEP_COUNT()\n" +
              "            + errStack.SELECTOR_HLEP_INDEX()\n" +
              "            + errStack.SELECTOR_HLEP_GET();\n" +
              "        },\n" +
              "        SCRIPT_ERR: function (desc) {\n" +
              "            return 'ERROR: JAVASCRIPT_ERROR_OCCOURED:\\n\\t' + desc;\n" +
              "        },\n" +
              "        EMPTY_ERR_COMMAND: function () {\n" +
              "            return 'ERROR: VALUE_EMPTY_ERROR_OCCOURED:\\n\\t Command should not be Empty';\n" +
              "        },\n" +
              "        EMPTY_ERR_TARGET: function () {\n" +
              "            return 'ERROR: VALUE_EMPTY_ERROR_OCCOURED:\\n\\t Target should not be Empty';\n" +
              "        },\n" +
              "        EMPTY_ERR_VALUE: function () {\n" +
              "            return 'ERROR: VALUE_EMPTY_ERROR_OCCOURED:\\n\\t value should not be Empty';\n" +
              "        },\n" +
              "        INVALIED_COMMAND: function (cmd) {\n" +
              "            return 'ERROR: INVALIED_COMMAND_ERROR_OCCOURED:\\n\\t given command(' + cmd + ') is not found in the below list \\n\\t Available Comamnds:click,set,select,store,verify,change';\n" +
              "        },\n" +
              "        INVALIED_TARGET: function (tar) {\n" +
              "            return 'ERROR: INVALIED_TARGET_ERROR_OCCOURED:\\n\\t given target(' + tar + ') and use below help' + errStack.SELECTOR_HLEP();\n" +
              "        },\n" +
              "        INVALIED_VALUE: function (val) {\n" +
              "            return 'ERROR: INVALIED_VALUE_ERROR_OCCOURED:\\n\\t' + val;\n" +
              "        },\n" +
              "        NOT_FOUND_ELEMENT: function (selector) {\n" +
              "            return 'ERROR: ELEMENT_NOT_FOUND_ERROR_OCCOURED:\\n\\t FOR SELECTOR >> ' + selector;\n" +
              "        },\n" +
              "        MULTIPLE_ELEMENTS_FOUND: function (selector) {\n" +
              "            return 'ERROR: MULTIPLE_ELEMENTS_FOUND_ERROR_OCCOURED:\\n\\t FOR SELECTOR >> ' + selector;\n" +
              "        },\n" +
              "        ACTION_NOTABEL_TO_PERFORM: function (action, reson) {\n" +
              "            return 'ERROR: ' + action.toUpperCase() + ' ACTION CANNOT BE COMPLETED BECAUSE OF:\\n\\t targeted element is >> ' + reson;\n" +
              "        }\n" +
              "\n" +
              "\n" +
              "\n" +
              "\n" +
              "\n" +
              "    };\n" +
              "\n" +
              "\n" +
              "    function formater(text) {\n" +
              "        var tomatch = [new RegExp('\\n', 'i'), new RegExp('\\f', 'i'), new RegExp('\\r', 'i'), new RegExp('\\t', 'i'), new RegExp('\\&lt;', 'i'), new RegExp('\\&gt;', 'i'), new RegExp('\\&amp;', 'i'), new RegExp('\\&quot;', 'i'), new RegExp('\\&apos;', 'i'), new RegExp('\\&cent;', 'i'), new RegExp('\\&pound;', 'i'), new RegExp('\\&yen;', 'i'), new RegExp('\\&euro;', 'i'), new RegExp('\\&copy;', 'i'), new RegExp('\\&reg;', 'i'), new RegExp('\\&nbsp;', 'i')];\n" +
              "        tomatch.forEach(function (item) {\n" +
              "            text = text.replace(item, '');\n" +
              "        });\n" +
              "        return text.trim().toLowerCase();\n" +
              "    }\n" +
              "    function isNumeric(n) {\n" +
              "        return !isNaN(parseFloat(n)) && isFinite(n);\n" +
              "    }\n" +
              "    var isTextStarts = function (keyword, itemtomatch) {\n" +
              "        if (new RegExp(keyword, 'i').exec(itemtomatch))\n" +
              "            return true;\n" +
              "        else\n" +
              "            return false;\n" +
              "    };\n" +
              "    function docService(tar){ \n" +
              "\n" +
              "        console.log('started.. with tar' + tar);\n" +
              "        var findByCondFilters = function (ele, condfilterselector) {\n" +
              "            var isActionElement = function (ele) {\n" +
              "                var retval = true;\n" +
              "                try {\n" +
              "                    if (ele.style.display !== 'none' && !ele.disabled && ele.style.visibility !== 'hidden') {\n" +
              "                        retval = true;\n" +
              "\n" +
              "                    } else {\n" +
              "                        retval = false;\n" +
              "                    }\n" +
              "                } catch (err) { }\n" +
              "                return retval;\n" +
              "            }\n" +
              "            if (!isActionElement(ele))\n" +
              "                return false;\n" +
              "            if (condfilterselector == '')\n" +
              "                return true;\n" +
              "\n" +
              "            var findByProp = function (ele, condfilterselector) {\n" +
              "                if (new RegExp('\\:\\=', 'i').exec(condfilterselector)) {\n" +
              "                    try {\n" +
              "                        var prop = condfilterselector.split(new RegExp('\\:\\=', 'i'))[0];\n" +
              "                        var val = condfilterselector.split(new RegExp('\\:\\=', 'i'))[1];\n" +
              "                        try {\n" +
              "                            if (formater(ele.getAttribute(prop)) == formater(val))\n" +
              "                                return true;\n" +
              "                        } catch (err) { }\n" +
              "\n" +
              "                        var attrs = ele.attributes;\n" +
              "                        var res = false;\n" +
              "\n" +
              "                        Array.prototype.slice.call(ele.attributes).forEach(function (item) {\n" +
              "                            if (formater(item.name) == formater(prop) && formater(item.value) == formater(val))\n" +
              "                                res = true;\n" +
              "                        });\n" +
              "                        return res;\n" +
              "\n" +
              "                    } catch (err) {\n" +
              "                        return false;\n" +
              "                    }\n" +
              "                } else {\n" +
              "                    return false;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByTag = function (ele, condfilterselector) {\n" +
              "                try {\n" +
              "\n" +
              "                    if (formater(ele.tagName) == formater(condfilterselector))\n" +
              "                        return true;\n" +
              "                    else\n" +
              "                        return false;\n" +
              "                } catch (err) {\n" +
              "                    return false;\n" +
              "                }\n" +
              "            };\n" +
              "\n" +
              "\n" +
              "            var applyConditions = function (ele, conditions) {\n" +
              "\n" +
              "                if (new RegExp('^not\\\\[', 'i').test(conditions)) {\n" +
              "                    conditions = conditions.replace(new RegExp('^not\\\\[', 'i'), '').replace(']', '');\n" +
              "                    if (findByProp(ele, conditions))\n" +
              "                        return false;\n" +
              "                    else\n" +
              "                        return true;\n" +
              "                } else if (new RegExp('^\\w+\\\\[', 'i').test(conditions)) {\n" +
              "                    var tag = conditions.split(new RegExp('\\\\[', 'i'))[0];\n" +
              "                    var props = conditions.split(new RegExp('\\\\[', 'i'))[1].replace(']', '');\n" +
              "                    if (findByTag(ele, tag) && findByProp(ele, props))\n" +
              "                        return true;\n" +
              "                    else\n" +
              "                        return false;\n" +
              "\n" +
              "                } else if (new RegExp('^\\\\[', 'i').test(conditions)) {\n" +
              "                    conditions = conditions.replace(new RegExp('^\\\\[', 'i'), '').replace(']', '');\n" +
              "                    return findByProp(ele, conditions);\n" +
              "                } else {\n" +
              "\n" +
              "                    return findByTag(ele, conditions);\n" +
              "                }\n" +
              "            }\n" +
              "            if (new RegExp('\\\\,', 'i').exec(condfilterselector)) {\n" +
              "                var res;\n" +
              "                var splitcond = condfilterselector.split(new RegExp('\\\\,', 'i'));\n" +
              "\n" +
              "                var applyAllConditions = function (ele, splitcond) {\n" +
              "                    var i = 0;\n" +
              "                    for (curcond in splitcond) {\n" +
              "                        var cres = applyConditions(ele, splitcond[curcond]);\n" +
              "                        if (!cres)\n" +
              "                            i = 1;\n" +
              "                    }\n" +
              "                    return i;\n" +
              "                }\n" +
              "                var resval = applyAllConditions(ele, splitcond);\n" +
              "                if (resval == 0)\n" +
              "                    res = true;\n" +
              "                else\n" +
              "                    res = false;\n" +
              "\n" +
              "            } else {\n" +
              "                res = applyConditions(ele, condfilterselector);\n" +
              "            }\n" +
              "\n" +
              "            return res;\n" +
              "        };\n" +
              "\n" +
              "        var findByBaseFilter = function (docobj, selector) {\n" +
              "            retval = [];\n" +
              "\n" +
              "            var findById = function (docobj, selector, condition) {\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.querySelectorAll('#' + selector);\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], condition))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByClass = function (docobj, selector, condition) {\n" +
              "\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.getElementsByClassName(selector);\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], condition))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByName = function (docobj, selector, condition) {\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.getElementsByName(selector);\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], condition))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByXPath = function (docobj, selector) {\n" +
              "                try {\n" +
              "                    return document.evaluate(selector, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;\n" +
              "                } catch (err) { return docobj; }\n" +
              "            };\n" +
              "            var findByText = function (docobj, selector, condition) {\n" +
              "\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                selector = formater(selector);\n" +
              "                try {\n" +
              "                    curres = docobj.getElementsByTagName('*');\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        curtext = curres[item].innerText || curres[item].innerHTML;\n" +
              "                        if (new RegExp('^' + selector, 'i').exec(formater(curtext)))\n" +
              "                            if (formater(curtext)==selector)\n" +
              "                                if (findByCondFilters(curres[item], condition))\n" +
              "                                    if(retnodes.length>0)\n" +
              "                                    {\n" +
              "                                        if(retnodes[retnodes.length-1]==curres[item].parentNode)\n" +
              "                                        {\n" +
              "                                            retnodes.pop();\n" +
              "                                        }\n" +
              "                                        retnodes.push(curres[item]);\n" +
              "                                    }else{\n" +
              "                                        retnodes.push(curres[item]);\n" +
              "                                    }                                    \n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByElement = function (docobj, selector) {\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.getElementsByTagName('*');\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], selector))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByParent = function (docobj, selector) {\n" +
              "                console.log('Came to findByParent Section for Selector >>' + selector);\n" +
              "                var res = [];\n" +
              "                var matchparent = function (curele, selector) {\n" +
              "                    var pNode = curele.parentNode;\n" +
              "                    try {\n" +
              "                        if (findByCondFilters(pNode, selector)) {\n" +
              "                            return pNode;\n" +
              "                        } else {\n" +
              "                            return matchparent(pNode, selector);\n" +
              "                        }\n" +
              "                    } catch (err34) {\n" +
              "                        return null;\n" +
              "                    }\n" +
              "\n" +
              "                };\n" +
              "                var item = matchparent(docobj, selector);\n" +
              "                if (item != null)\n" +
              "                    res.push(item);\n" +
              "                return res;\n" +
              "            };\n" +
              "            var findByChild = function (docobj, selector) {\n" +
              "                console.log('Came to findByChild Section for Selector >>' + selector);\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.childNodes;\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], selector))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByIndex = function (docobj, selector) {\n" +
              "                console.log('Came to findByIndex Section for Selector >>' + selector);\n" +
              "                var retnodes = [];\n" +
              "                if (Array.isArray(docobj)) {\n" +
              "                    if (new RegExp('first', 'i').exec(selector))\n" +
              "                        retnodes.push(docobj[0]);\n" +
              "                    else if (new RegExp('last', 'i').exec(selector))\n" +
              "                        retnodes.push(docobj[docobj.length - 1]);\n" +
              "                    else {\n" +
              "                        try {\n" +
              "                            retnodes.push(docobj[parseInt(selector)]);\n" +
              "                        } catch (err) { return null; }\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } else {\n" +
              "                    return null;\n" +
              "                }\n" +
              "            };\n" +
              "            var findByCount = function (docobj, selector) {\n" +
              "                console.log('Came to findByCount Section for Selector >>' + selector);\n" +
              "                var retnodes = [];\n" +
              "                if (Array.isArray(docobj)) {\n" +
              "                    return docobj.length;\n" +
              "                } else {\n" +
              "                    return 0;\n" +
              "                }\n" +
              "            };\n" +
              "            var findByQuery = function (docobj, selector) {\n" +
              "                console.log('Came to findByQuery Section for Selector >>' + selector);\n" +
              "                var retnodes = [], curres, curselector;\n" +
              "                try {\n" +
              "                    curres = docobj.querySelectorAll(selector);\n" +
              "                    for (var item = 0; item < curres.length; item++) {\n" +
              "                        if (findByCondFilters(curres[item], ''))\n" +
              "                            retnodes.push(curres[item]);\n" +
              "\n" +
              "                    }\n" +
              "                    return retnodes;\n" +
              "                } catch (er) {\n" +
              "                    return null;\n" +
              "                }\n" +
              "\n" +
              "            };\n" +
              "            var findByGet = function (elt, selector) {\n" +
              "                console.log('Came to findByGet Section for Selector >>' + selector);\n" +
              "                if (new RegExp('text', 'i').exec(selector)) {\n" +
              "                    if (new RegExp('input', 'i').exec(elt.tagName) || new RegExp('textarea', 'i').exec(elt.tagName)) {\n" +
              "                        return elt.value;\n" +
              "                    } else if (new RegExp('select', 'i').exec(elt.tagName)) {\n" +
              "                        return elt.options[elt.selectedIndex].text || elt.options[elt.selectedIndex].innerText || elt.options[elt.selectedIndex].innerHTML;\n" +
              "                    } else {\n" +
              "                        return elt.innerText || elt.innerHTML;\n" +
              "                    }\n" +
              "                } else if (new RegExp('xpath', 'i').exec(selector)) {\n" +
              "                    var path = '';\n" +
              "                    var getElementIdx = function (elt) {\n" +
              "                        var count = 1;\n" +
              "                        for (var sib = elt.previousSibling; sib ; sib = sib.previousSibling) {\n" +
              "                            if (sib.nodeType == 1 && sib.tagName == elt.tagName) { count++ }\n" +
              "                        } return count;\n" +
              "                    };\n" +
              "                    for (; elt && elt.nodeType == 1; elt = elt.parentNode) {\n" +
              "\n" +
              "                        var idx = getElementIdx(elt); var xname = elt.tagName;\n" +
              "                        if (idx > 1) xname += '[' + idx + ']'; path = '/' + xname + path;\n" +
              "                    }\n" +
              "                    return '/' + path;\n" +
              "                } else {\n" +
              "                    try {\n" +
              "                        return formater(elt.getAttribute(selector));\n" +
              "                    } catch (err) {\n" +
              "                        return null;\n" +
              "                    }\n" +
              "                }\n" +
              "            };\n" +
              "            var findBy = function (docobj, selector) {\n" +
              "                console.log('Came to findBy Section for Selector >>' + selector);\n" +
              "\n" +
              "                var retval = [], apply = false;\n" +
              "                if (new RegExp('\\\\,', 'i').exec(selector))\n" +
              "                    apply = true;\n" +
              "                if (new RegExp('^\\#\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^\\#\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    if (apply)\n" +
              "                        retval = findById(docobj, selector.split(new RegExp('\\\\,', 'i'))[0], selector.replace(selector.split(new RegExp('\\\\,', 'i'))[0], ''));\n" +
              "                    else\n" +
              "                        retval = findById(docobj, selector, '');\n" +
              "                } else if (new RegExp('^\\\\.\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^\\\\.\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    if (apply)\n" +
              "                        retval = findByClass(docobj, selector.split(new RegExp('\\\\,', 'i'))[0], selector.replace(selector.split(new RegExp('\\\\,', 'i'))[0], ''));\n" +
              "                    else\n" +
              "                        retval = findByClass(docobj, selector, '');\n" +
              "                } else if (new RegExp('^n\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^n\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    if (apply)\n" +
              "                        retval = findByName(docobj, selector.split(new RegExp('\\\\,', 'i'))[0], selector.replace(selector.split(new RegExp('\\\\,', 'i'))[0], ''));\n" +
              "                    else\n" +
              "                        retval = findByName(docobj, selector, '');\n" +
              "                } else if (new RegExp('^x\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^x\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByXPath(docobj, selector);\n" +
              "                } else if (new RegExp('^t\\\\(', 'i').exec(selector)) {\n" +
              "                    \n" +
              "                    selector = selector.replace(new RegExp('^t\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    if (apply)\n" +
              "                        retval = findByText(docobj, selector.split(new RegExp('\\\\,', 'i'))[0], selector.replace(selector.split(new RegExp('\\\\,', 'i'))[0], ''));\n" +
              "                    else\n" +
              "                        retval = findByText(docobj, selector, '');\n" +
              "                } else if (new RegExp('^e\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^e\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByElement(docobj, selector);\n" +
              "                } else if (new RegExp('^p\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^p\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByParent(docobj, selector);\n" +
              "                } else if (new RegExp('^c\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^c\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByChild(docobj, selector);\n" +
              "                } else if (new RegExp('^q\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^q\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByQuery(docobj, selector);\n" +
              "                } else if (new RegExp('^i\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^i\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByIndex(docobj, selector);\n" +
              "                } else if (new RegExp('^g\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^g\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByGet(docobj, selector);\n" +
              "                } else if (new RegExp('^count\\\\(', 'i').exec(selector)) {\n" +
              "                    selector = selector.replace(new RegExp('^count\\\\(', 'i'), '').replace(new RegExp('\\\\)', 'i'), '');\n" +
              "                    retval = findByCount(docobj, selector);\n" +
              "                } else {\n" +
              "                    retval = errStack.INVALIED_TARGET(selector);\n" +
              "                }\n" +
              "                if (typeof retval == errStack.INVALIED_TARGET)\n" +
              "                    return retval;\n" +
              "\n" +
              "                if (retval !== null) {\n" +
              "                    var curres = [];\n" +
              "                    if (Array.isArray(retval)) {\n" +
              "                        retval.forEach(function (ele) {\n" +
              "                            if (typeof ele == 'object' || typeof ele == 'string' || isNumeric(ele))\n" +
              "                                curres.push(ele);\n" +
              "                        });\n" +
              "                        return curres;\n" +
              "                    } else {\n" +
              "                        if (typeof retval == 'string' || isNumeric(retval))\n" +
              "                            curres = retval;\n" +
              "                        else\n" +
              "                            curres.push(retval);\n" +
              "                        return curres;\n" +
              "                    }\n" +
              "\n" +
              "                } else {\n" +
              "                    return docobj;\n" +
              "                }\n" +
              "            };\n" +
              "            if (Array.isArray(docobj)) {\n" +
              "                var curres;\n" +
              "                if (typeof docobj == document)\n" +
              "                    console.log('started.. with Object >> ' + 'document');\n" +
              "                else if (Array.isArray(docobj))\n" +
              "                    console.log('started.. with Object' + 'Array Subset');\n" +
              "\n" +
              "                if (new RegExp('^i\\\\(', 'i').exec(selector) || new RegExp('^count\\\\(', 'i').exec(selector)) {\n" +
              "                    retval = findBy(docobj, selector);\n" +
              "                } else {\n" +
              "                    for (var item = 0; item < docobj.length; item++) {\n" +
              "                        curobj = docobj[item];\n" +
              "                        curres = findBy(curobj, selector);\n" +
              "                        if (curres != null) {\n" +
              "                            try {\n" +
              "                                if (Array.isArray(curres)) {\n" +
              "                                    curres.forEach(function (ele) {\n" +
              "                                        try {\n" +
              "                                            retval.push(ele);\n" +
              "                                        } catch (er) { }\n" +
              "                                    });\n" +
              "                                }\n" +
              "                                else\n" +
              "                                    retval = curres;\n" +
              "                            } catch (err) { }\n" +
              "                        }\n" +
              "                    }\n" +
              "\n" +
              "                }\n" +
              "            } else {\n" +
              "                retval = findBy(docobj, selector);\n" +
              "            }\n" +
              "            var cres = [];\n" +
              "            if (typeof retval == errStack.INVALIED_TARGET || retval == null || typeof retval == errStack.NOT_FOUND_ELEMENT)\n" +
              "                return retval;\n" +
              "\n" +
              "            if (Array.isArray(retval)) {\n" +
              "                retval.forEach(function (ele) {\n" +
              "                    if (typeof ele == 'object' || typeof ele == 'string' || isNumeric(ele))\n" +
              "                        cres.push(ele);\n" +
              "                });\n" +
              "\n" +
              "            } else {\n" +
              "\n" +
              "                if (typeof retval == 'string' || isNumeric(retval))\n" +
              "                    cres = retval;\n" +
              "                else\n" +
              "                    cres.push(retval);\n" +
              "\n" +
              "\n" +
              "            }\n" +
              "            return cres;\n" +
              "\n" +
              "        };\n" +
              "\n" +
              "        var split_selector = [], resultset = [], gblContext;\n" +
              "        if (new RegExp('\\=\\>', 'i').exec(tar))\n" +
              "            split_selector = tar.split(new RegExp('\\=\\>', 'i'));\n" +
              "        else\n" +
              "            split_selector.push(tar);\n" +
              "        gblContext = [];\n" +
              "        gblContext.push(document);\n" +
              "        \n" +
              "\n" +
              "        for (cur in gblContext) {\n" +
              "            curres = gblContext[cur];\n" +
              "            for (cselector in split_selector) {\n" +
              "                curres = findByBaseFilter(curres, split_selector[cselector]);\n" +
              "\n" +
              "                if (typeof curres == 'string' || isNumeric(curres)) {\n" +
              "                    return curres;\n" +
              "                }\n" +
              "                if (Array.isArray(curres)) {\n" +
              "                    resultset = curres;\n" +
              "                }\n" +
              "            }\n" +
              "        }\n" +
              "        if (Array.isArray(resultset)) {\n" +
              "            var returnvals = [];\n" +
              "            resultset.forEach(function (ele) {\n" +
              "                if (typeof ele == 'object' || typeof ele == 'string' || isNumeric(ele))\n" +
              "                    returnvals.push(ele);\n" +
              "            });\n" +
              "\n" +
              "            resultset = returnvals;\n" +
              "        }\n" +
              "        if (Array.isArray(resultset)) {\n" +
              "            if (resultset.length > 1)\n" +
              "                return errStack.MULTIPLE_ELEMENTS_FOUND();\n" +
              "            else\n" +
              "                return resultset[0];\n" +
              "        } else {\n" +
              "            return resultset;\n" +
              "        }\n" +
              "\n" +
              "\n" +
              "    }\n" +
              "\n" +
              "\n" +
              "    if (!new RegExp('set|sel|click|verify|store|change|test', 'i').exec(cmd))\n" +
              "        return errStack.INVALIED_COMMAND(cmd);\n" +
              "\n" +
              "    console.log('started.. with Command' + cmd);\n" +
              "    var curobj = docService(tar);\n" +
              "    \n" +
              "    if (typeof curobj == errStack.SELECTOR_HLEP_INDEX || typeof curobj == errStack.MULTIPLE_ELEMENTS_FOUND || typeof curobj == errStack.NOT_FOUND_ELEMENT)\n" +
              "        return curobj;\n" +
              "\n" +
              "    function fireEvent(element, event) {\n" +
              "        var res = '';\n" +
              "        try {\n" +
              "\n" +
              "            if (document.createEventObject) {\n" +
              "                var evt = document.createEventObject();\n" +
              "                return element.fireEvent('on' + event, evt);\n" +
              "            } else {\n" +
              "                var evt = document.createEvent('HTMLEvents');\n" +
              "                evt.initEvent(event, true, true);\n" +
              "                return !element.dispatchEvent(evt);\n" +
              "            }\n" +
              "        } catch (err) {\n" +
              "            res = errStack.SCRIPT_ERR(err);\n" +
              "        }\n" +
              "        return res;\n" +
              "    }\n" +
              "\n" +
              "    var highlight = function (iele) {\n" +
              "        try {\n" +
              "            var ibgcolor;\n" +
              "            if ((iele.type === 'button' || 'submit') || iele.nodeName === 'BUTTON') {\n" +
              "                ibgcolor = iele.style.border;\n" +
              "                iele.style.border = '3px solid #04DFFC';\n" +
              "                var t = setTimeout(function () {\n" +
              "                    iele.style.border = ibgcolor;\n" +
              "                }, 800);\n" +
              "            } else {\n" +
              "                ibgcolor = iele.style.backgroundColor;\n" +
              "                iele.style.backgroundColor = '#04DFFC'; var t = setTimeout(function () {\n" +
              "                    iele.style.backgroundColor = ibgcolor;\n" +
              "                }, 800);\n" +
              "            }\n" +
              "        } catch (err4) {\n" +
              "        }\n" +
              "    }\n" +
              "    var eScroll = function (iele) {\n" +
              "        try {\n" +
              "            window.scrollTo(iele.offsetLeft, iele.offsetTop);\n" +
              "            highlight(iele);\n" +
              "        } catch (err2) { }\n" +
              "    }\n" +
              "    var doClick = function (ele) {\n" +
              "        if (ele == null || typeof ele == 'string' || isNumeric(ele))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('click', ele);\n" +
              "\n" +
              "        eScroll(ele);\n" +
              "        try {\n" +
              "            console.log(fireEvent(ele, 'click'));\n" +
              "            return '';\n" +
              "        } catch (err) {\n" +
              "            try {\n" +
              "                if (typeof ele.onclick == 'function') {\n" +
              "                    ele.onclick();\n" +
              "                    return '';\n" +
              "                }\n" +
              "                else {\n" +
              "                    ele.click();\n" +
              "                    return '';\n" +
              "                }\n" +
              "\n" +
              "            } catch (ee) {\n" +
              "                return errStack.ACTION_NOTABEL_TO_PERFORM('click', ee);\n" +
              "            }\n" +
              "\n" +
              "        }\n" +
              "    }\n" +
              "    var doSet = function (ele, val) {\n" +
              "        if (ele == null || typeof ele == 'string' || isNumeric(ele))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('click', ele);\n" +
              "\n" +
              "        if (val == null)\n" +
              "            return errStack.INVALIED_VALUE(val);\n" +
              "\n" +
              "        eScroll(ele);\n" +
              "        try {\n" +
              "            ele.value = val;\n" +
              "            fireEvent(ele, 'keydown');\n" +
              "            fireEvent(ele, 'keyup');\n" +
              "            fireEvent(ele, 'change');\n" +
              "            return '';\n" +
              "        } catch (err) {\n" +
              "            try {\n" +
              "                if (typeof ele.onkeydown == 'function') {\n" +
              "                    ele.keydown();\n" +
              "                }\n" +
              "                if (typeof ele.onkeyup == 'function') {\n" +
              "                    ele.keyup();\n" +
              "                }\n" +
              "                if (typeof ele.onchange == 'function') {\n" +
              "                    ele.onchange();\n" +
              "                }\n" +
              "                return '';\n" +
              "\n" +
              "            } catch (ee) {\n" +
              "                return errStack.ACTION_NOTABEL_TO_PERFORM('set', ee);\n" +
              "            }\n" +
              "\n" +
              "        }\n" +
              "    }\n" +
              "    var doSelect = function (ele, val) {\n" +
              "        if (ele == null || typeof ele == 'string' || isNumeric(ele))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('Select', ele);\n" +
              "\n" +
              "        if (val == null || val == '')\n" +
              "            return errStack.INVALIED_VALUE(val);\n" +
              "\n" +
              "        if (formater(ele.tagName) !== formater('select'))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('Select', ele);\n" +
              "\n" +
              "        eScroll(ele);\n" +
              "        try {\n" +
              "            var allSel = ele.getElementsByTagName('option');\n" +
              "            for (var i = 0; i < allSel.length; i++) {\n" +
              "                if (formater(allSel[i].innerText || allSel[i].innerHTML) == formater(val)) {\n" +
              "                    ele.selectedIndex = i;\n" +
              "                    try {\n" +
              "                        fireEvent(ele, 'change');\n" +
              "                    } catch (err) {\n" +
              "                        if (typeof ele.onchange == 'function')\n" +
              "                            ele.onchange();\n" +
              "                    }\n" +
              "                    break;\n" +
              "                }\n" +
              "            }\n" +
              "            return '';\n" +
              "        } catch (err) {\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('Sel', ee);\n" +
              "        }\n" +
              "\n" +
              "    }\n" +
              "    var doVerify = function (act, base) {\n" +
              "        if (typeof act == 'string' || isNumeric(act)) {\n" +
              "            if (formater(base) == formater(act))\n" +
              "                return '';\n" +
              "            else\n" +
              "                return errStack.ACTION_NOTABEL_TO_PERFORM('verify', 'difference between base <<' + base + '>> \\n and actual <<' + act + '>>');\n" +
              "        }\n" +
              "        else {\n" +
              "            if (typeof base !== 'string' || !isNumeric(base))\n" +
              "                return errStack.ACTION_NOTABEL_TO_PERFORM('verify', 'Expecting string or Number to verify but actual type is >> ' + typeof act);\n" +
              "\n" +
              "        }\n" +
              "\n" +
              "\n" +
              "\n" +
              "\n" +
              "\n" +
              "    }\n" +
              "    var doStore = function (act) {\n" +
              "        if (typeof act == 'string' || isNumeric(act))\n" +
              "            return act;\n" +
              "        else\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('store', 'Expecting string or Number to verify but actual type is >> ' + typeof act);\n" +
              "\n" +
              "    }\n" +
              "    var doChange = function (ele, val) {\n" +
              "        if (ele == null || typeof ele == 'string' || isNumeric(ele))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('change', ele);\n" +
              "        if (val == '' || val == null || !new RegExp('\\:\\=', 'i').exec(val))\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('change', val);\n" +
              "        var prop = val.split(new RegExp('\\:\\=', 'i'))[0];\n" +
              "        var propval = val.split(new RegExp('\\:\\=', 'i'))[1];\n" +
              "        try {\n" +
              "            eScroll(ele);\n" +
              "            if (new RegExp('class', 'i').exec(prop))\n" +
              "                ele.className = propval;\n" +
              "            else if (new RegExp('id', 'i').exec(prop))\n" +
              "                ele.id = propval;\n" +
              "            else if (new RegExp('name', 'i').exec(prop))\n" +
              "                ele.name = propval;\n" +
              "            else if (new RegExp('value', 'i').exec(prop))\n" +
              "                ele.value = propval;\n" +
              "            else if (new RegExp('text', 'i').exec(prop))\n" +
              "                ele.innerHTML = propval;\n" +
              "            else\n" +
              "                ele.setAttribute(prop, propval);\n" +
              "\n" +
              "            fireEvent(ele, 'change');\n" +
              "            return '';\n" +
              "        } catch (err) {\n" +
              "            return errStack.ACTION_NOTABEL_TO_PERFORM('change', err);\n" +
              "        }\n" +
              "    }\n" +
              "\n" +
              "    var doTest = function (ele, val) {\n" +
              "        if (ele == null || typeof ele == 'string' || isNumeric(ele))\n" +
              "            return errStack.NOT_FOUND_ELEMENT(ele);\n" +
              "\n" +
              "        eScroll(ele);\n" +
              "    }\n" +
              "    var res = '';\n" +
              "\n" +
              "    if (new RegExp('click', 'i').exec(cmd)) {\n" +
              "        res = doClick(curobj);\n" +
              "    } else if (new RegExp('set', 'i').exec(cmd)) {\n" +
              "        res = doSet(curobj, val);\n" +
              "    } else if (new RegExp('sel', 'i').exec(cmd)) {\n" +
              "        res = doSelect(curobj, val);\n" +
              "    } else if (new RegExp('verify', 'i').exec(cmd)) {\n" +
              "        res = doVerify(curobj, val);\n" +
              "    } else if (new RegExp('store', 'i').exec(cmd)) {\n" +
              "        res = doStore(curobj);\n" +
              "    } else if (new RegExp('change', 'i').exec(cmd)) {\n" +
              "        res = doChange(curobj, val);\n" +
              "    } else if (new RegExp('test', 'i').exec(cmd)) {\n" +
              "        res = doTest(curobj);\n" +
              "    } else {\n" +
              "        res = errStack.INVALIED_COMMAND(cmd);\n" +
              "    }\n" +
              "\n" +
              "    return res;\n" +
              "\n" +
              "}";
        }



    }
}
